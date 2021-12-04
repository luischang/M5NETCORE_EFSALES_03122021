using M5NETCORE_EFSALES.CORE.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace M5NETCORE_EFSALES.INFRASTRUCTURE.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception.GetType() == typeof(GeneralException))
            {
                var exception = (GeneralException)filterContext.Exception;
                var validation = new
                {
                    Status = 400,
                    Title = "Bad Request API Sales",
                    Detail = exception.Message
                };

                var json = new
                {
                    errors = new[] { validation }
                };

                filterContext.Result = new BadRequestObjectResult(json);
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                filterContext.ExceptionHandled = true;

            }
        }
    }
}
