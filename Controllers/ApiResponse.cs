using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_net_ecommerce_web_api.Controllers
{
    public class ApiResponse<T>//generic type data
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;

        public T? Data { get; set; }

        public List<string>? Errors { get; set; }

        public int StatusCode { get; set; }

        public DateTime TimeStamp { get; set; }

        //Constructor for successful response
        public ApiResponse(bool success,string message,T data,List<string> errors, int statusCode ){
            Success = success;
            Message = message;
            Data = data;
            Errors = null;
            StatusCode = statusCode;
            TimeStamp = DateTime.UtcNow;
        }

        //static method for creating a successful response
        public static ApiResponse<T> SuccessResponse(T data,int statusCode, string message="")
        {
            return new ApiResponse<T>(true,message,data,null,statusCode);
        }

        //static method for creating a Error response
        public static ApiResponse<T> ErrorResponse(List<string> errors,int statusCode, string message="")
        {
            return new ApiResponse<T>(false,message,default(T),errors,statusCode);
        }
    }
}