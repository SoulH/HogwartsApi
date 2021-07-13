using System.Collections.Generic;

namespace Core.Models
{
    public class ResponseData<T>
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }

        public IEnumerable<T> Result { get; set; }

        public IDictionary<string, string[]> Detail { get; set; }

        public static ResponseData<T> Ok(IEnumerable<T> result, string message = null) => new ResponseData<T>
        {
            Success = true,
            Message = message,
            Result = result
        };

        public static ResponseData<T> Ok(T data, string message = null) => new ResponseData<T>
        {
            Success = true,
            Message = message,
            Data = data
        };

        public static ResponseData<T> Error(IDictionary<string, string[]> detail = null, string message = null) => new ResponseData<T>
        {
            Success = false,
            Message = message,
            Detail = detail
        };

    }
}
