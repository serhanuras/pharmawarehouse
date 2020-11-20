using Microsoft.AspNetCore.Mvc.Filters;
using PharmaWarehouse.Api.Modules.Extensions;

namespace PharmaWarehouse.Api.Modules.Attributes
{
    public class HasSensitiveDataAttribute : ActionFilterAttribute
    {
        private readonly SensitiveDataInPlace sensitiveDataInPlace;

        public HasSensitiveDataAttribute(SensitiveDataInPlace sensitiveDataInPlace = SensitiveDataInPlace.Both)
        {
            this.sensitiveDataInPlace = sensitiveDataInPlace;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Request.Headers["SensitiveDataInPlace"] = this.sensitiveDataInPlace.ToString();
        }
    }
}
