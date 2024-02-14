using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Library.CommonLayer.Result
{
    public class ApiController : ControllerBase
    {
        [NonAction]
        public ApiResult CommandResult()
        {
            //HttpContext.Response.StatusCode = (int)result.Status;
            return new ApiResult()
            {
                IsSuccess = true,
                MetaData = new()
                {
                    Message = "Operation was Successfull",
                    AppStatusCode = AppStatusCode.Success,
                }
            };
        }

        //[NonAction]
        //public ApiResult<TData?> CommandResult<TData>(OperationResult<TData> result
        //     , string locationUrl = null)
        //{
        //    bool isSuccess = result.Status == OperationResultStatus.Success;
        //    HttpContext.Response.StatusCode = (int)result.Status;
        //    if (isSuccess)
        //    {
        //        //HttpContext.Response.StatusCode =(int) HttpStatusCode.OK;
        //        if (!string.IsNullOrWhiteSpace(locationUrl))
        //        {
        //            HttpContext.Response.Headers.Add("location", locationUrl);
        //        }
        //    }
        //    return new ApiResult<TData?>()
        //    {
        //        IsSuccess = isSuccess,
        //        Data = isSuccess ? result.Data : default,
        //        MetaData = new()
        //        {
        //            Message = result.Message,
        //            AppStatusCode = result.Status.MapOperationStatus()
        //        }
        //    };
        //}

        [NonAction]
        public ApiResult<TData> QueryResult<TData>(TData result)
        {
            //HttpContext.Response.StatusCode = (int)result.Status;
            if(result != null)
            {
                return new ApiResult<TData>()
                {
                    IsSuccess = true,
                    Data = result,
                    MetaData = new()
                    {
                        Message = "Data uploded Successfully",
                        AppStatusCode = AppStatusCode.Success
                    }
                };
            }
            return new ApiResult<TData>()
            {
                IsSuccess = true,
                MetaData = new()
                {
                    Message = "Data uploded Successfully",
                    AppStatusCode = AppStatusCode.Success
                }
            };

        }
    }


    //public static class EnumHelper
    //{
    //    public static AppStatusCode MapOperationStatus(this OperationResultStatus status)
    //    {
    //        switch (status)
    //        {
    //            case OperationResultStatus.Success:
    //                return AppStatusCode.Success;

    //            case OperationResultStatus.NotFound:
    //                return AppStatusCode.NotFound;

    //            case OperationResultStatus.Error:
    //                return AppStatusCode.ServerError;

    //            case OperationResultStatus.LogicError:
    //                return AppStatusCode.LogicError;

    //            case OperationResultStatus.UnAuthorize:
    //                return AppStatusCode.UnAuthorize;
    //        }
    //        return AppStatusCode.ServerError;
    //    }
    //}
}
