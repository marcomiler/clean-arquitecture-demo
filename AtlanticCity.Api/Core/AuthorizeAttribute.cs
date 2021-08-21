using AtlanticCity.Core.Core;
using AtlanticCity.Core.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]

public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var userName = context.HttpContext.Items["UserName"];
        var userId = context.HttpContext.Items["UserId"];

        if(userName == null && userId == null)
        {
            Response response = new(null, "Unauthorized");
            context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Result = new JsonResult(response);
        }
        else
        {
            var itemsContext = context.HttpContext.Items;
            var keys = itemsContext.Keys.ToList().Select(k => (string)k).ToList();

            EntityContext.UserName = userName.ToString();
            EntityContext.UserId = new Guid(userId.ToString()); 
        }
    }
}

