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
        public ApiResponse(T data, int statusCode, string message=""){
            Success = true;
            Message = message;
            Data = data;
            Errors = null;
            StatusCode = statusCode;
            TimeStamp = DateTime.UtcNow;
        }

        //Constructor for error response
        
    }
}