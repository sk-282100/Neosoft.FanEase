using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace Neosoft.FAMS.WebApp
{
    public class CustomAuthorizationFilter : ActionFilterAttribute,IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var roleId = context.HttpContext.Session.GetString("RoleId");
            if (roleId == null)
            {
                context.Result =
                    new RedirectToRouteResult(
                        new RouteValueDictionary{{ "controller", "Error" },
                            { "action", "Error401" }
                        });
                return;
            }
            await next();
        }
    }
}
