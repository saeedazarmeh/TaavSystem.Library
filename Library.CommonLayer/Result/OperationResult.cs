using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.CommonLayer.Result
{
    public class OperationResult<TData>
    {

        public string Message { get; set; }
        public string Title { get; set; } = null;
        public OperationResultStatus Status { get; set; }
        public TData Data { get; set; }
        public static OperationResult<TData> Success(TData data,string message)
        {
            return new OperationResult<TData>()
            {
                Status = OperationResultStatus.Success,
                Title = message,
                Data = data,
            };
        }
        public static OperationResult<TData> LogicError()
        {
            return new OperationResult<TData>()
            {
                Status = OperationResultStatus.LogicError,
                Title = "LogicError",
                Message = "Operation was Successful",
                Data = default,
            };
        }
        public static OperationResult<TData> UnAuthorize()
        {
            return new OperationResult<TData>()
            {
                Status = OperationResultStatus.UnAuthorize,
                Title = "UnAuthorize",
                Message = "Operation was Stop by UnAuthorizeError",
                Data = default,
            };
        }
        public static OperationResult<TData> NotFound()
        {
            return new OperationResult<TData>()
            {
                Status = OperationResultStatus.NotFound,
                Title = "NotFound",
                Message = "Operation was Stop by NotFoundError",
                Data = default,
            };
        }

        public static OperationResult<TData> Error(string message)
        {
            return new OperationResult<TData>()
            {
                Status = OperationResultStatus.Error,
                Message = message,
                Data = default,
            };
        }
    }
    public class OperationResult
    {
        public const string SuccessMessage = "عملیات با موفقیت انجام شد";
        public const string ErrorMessage = "عملیات با شکست مواجه شد";
        public const string NotFoundMessage = "اطلاعات یافت نشد";
        public string Message { get; set; }
        public string Title { get; set; } = null;
        public OperationResultStatus Status { get; set; }

     
        public static OperationResult NotFound(string message)
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.NotFound,
                Message = message,
            };
        }
        public static OperationResult NotFound()
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.NotFound,
                Message = NotFoundMessage,
            };
        }

        public static OperationResult Error()
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.Error,
                Message = ErrorMessage,
            };
        }

        public static OperationResult Error(string message)
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.Error,
                Message = message,
            };
        }
        public static OperationResult Success()
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.Success,
                Message = SuccessMessage,
            };
        }
        public static OperationResult Success(string message)
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.Success,
                Message = message,
            };
        }
        public static OperationResult LogicError(string message)
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.LogicError,
                Message = message,
            };
        }

        public static OperationResult UnAuthorize(string message)
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.UnAuthorize,
                Message = message,
            };
        }
    }


    public enum OperationResultStatus
    {
        Error = 500,
        Success = 200,
        NotFound = 404,
        LogicError = 409,
        UnAuthorize = 401,
    }
}
