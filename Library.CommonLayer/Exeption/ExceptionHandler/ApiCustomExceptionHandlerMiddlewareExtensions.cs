using Library.CommonLayer.Result;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Library.CommonLayer.Exeption.ExceptionHandler
{
    public static class ApiCustomExceptionHandlerMiddlewareExtensions
    {

        public static IApplicationBuilder UseApiCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleWare>();
        }
    }

    /// <summary>
    /// Imlemented Middleware
    /// </summary>
    public class ExceptionHandlerMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly IHostingEnvironment _env;
        private readonly ILogger<ExceptionHandlerMiddleWare> _logger;

        public ExceptionHandlerMiddleWare(RequestDelegate next,
            IHostingEnvironment env,
            ILogger<ExceptionHandlerMiddleWare> logger)
        {
            _next = next;
            _env = env;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            string message = null;
            AppStatusCode apiStatusCode = AppStatusCode.ServerError;

            try
            {
                await _next(context);
            }
            catch (InvalidDataException exception)
            {
                _logger.LogError(exception, exception.Message);
                apiStatusCode = AppStatusCode.InvalidData;
                SetErrorMessage(exception);
                await WriteToResponseAsync();
            }
            catch (LogicExeption exception)
            {
                _logger.LogError(exception, exception.Message);
                apiStatusCode = AppStatusCode.LogicError;
                SetErrorMessage(exception);
                await WriteToResponseAsync();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                SetErrorMessage(exception);
                await WriteToResponseAsync();
            }

            void SetErrorMessage(Exception exception)
            {
                message = exception.Message;
                if (_env.IsDevelopment())
                {
                    var dic = new Dictionary<string, string>
                    {
                        ["Exception"] = exception.Message,
                        ["StackTrace"] = exception.StackTrace,
                    };
                    if (exception.InnerException != null)
                    {
                        dic.Add("InnerException.Exception", exception.InnerException.Message);
                        dic.Add("InnerException.StackTrace", exception.InnerException.StackTrace);
                    }

                    message = JsonConvert.SerializeObject(dic);
                }
            }
            async Task WriteToResponseAsync()
            {
                if (context.Response.HasStarted)
                    throw new InvalidOperationException("The response has already started, the http status code middleware will not be executed.");

                var result = new ApiResult()
                {
                    IsSuccess = false,
                    MetaData = new()
                    {
                        AppStatusCode = apiStatusCode,
                        Message = message
                    }
                };
                var json = JsonConvert.SerializeObject(result);

                context.Response.StatusCode = (int)apiStatusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);
            }
        }
    }
}
