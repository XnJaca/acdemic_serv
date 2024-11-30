using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace acdemic_serv.Utils
{
    public class BaseController : ControllerBase
    {

        // SUCCESS RESPONSE
        protected ActionResult<T> SuccessResponse<T>(T data, string message = "Success")
        {
            return Ok(new
            {
                status = true,
                message,
                data
            });
        }

        // ERROR RESPONSE
        protected ActionResult<T> ErrorResponse<T>(T? data, string message = "Unexpected error")
        {
            return Ok(new
            {
                status = false,
                message,
                data
            });
        }

    }
}