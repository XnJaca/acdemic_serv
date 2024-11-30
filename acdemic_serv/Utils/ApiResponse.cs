using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace acdemic_serv.Utils
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }

        public static ApiResponse<T> SuccessResponse(T data) => new() { Success = true, Data = data };
        public static ApiResponse<T> ErrorResponse(string message) => new() { Success = false, Message = message };
    }
}