using Microsoft.AspNetCore.Mvc.Filters;

namespace PharmaWarehouse.Api.Modules.Attributes
{
    public class PublicMethodAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
    }
}
