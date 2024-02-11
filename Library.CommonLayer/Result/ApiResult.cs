using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.CommonLayer.Result
{
    public class ApiResult
    {
        public bool IsSuccess { get; set; }
        public MetaData MetaData { get; set; }
    }
    public class ApiResult<TData>
    {
        public bool IsSuccess { get; set; }
        public TData Data { get; set; }
        public MetaData MetaData { get; set; }
    }
    public class MetaData
    {
        public string Message { get; set; }
        public AppStatusCode AppStatusCode { get; set; }
    }

    public enum AppStatusCode
    {
        Success = 200,
        NotFound = 404,
        InvalidData = 422,
        BadRequest = 400,
        LogicError = 409,
        UnAuthorize = 401,
        ServerError = 500,
    }
}
