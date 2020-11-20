using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using PharmaWarehouse.Api.Dtos;
using PharmaWarehouse.Api.Modules.Exceptions;

namespace PharmaWarehouse.Api.Modules.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger logger;

        public ExceptionFilter(
            ILogger<ExceptionFilter> logger)
        {
            this.logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Request.Headers["StartDateTime"] =
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff");

            this.logger.LogError(context.Exception, context.Exception.Message);

            if (context.Exception.GetType() == typeof(UnauthorizedAccessException))
            {
                context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
            }
            else if (context.Exception.GetType() == typeof(NotFoundException))
            {
                context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
            }
            else
            {
                context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;

                ErrorDto errorDto = new ErrorDto()
                {
                    Message = "MESSAGE : " + context.Exception.Message + " -  STACK TRACE :" +
                              context.Exception.StackTrace,
                };
                context.Result = new ObjectResult(errorDto);

                context.HttpContext.Request.Headers["ResponseBody"] = errorDto.Message;

                context.ExceptionHandled = true;
            }

            base.OnException(context);
        }
    }
}
