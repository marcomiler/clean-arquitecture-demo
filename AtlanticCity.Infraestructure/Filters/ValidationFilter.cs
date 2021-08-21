using AtlanticCity.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace AtlanticCity.Infraestructure.Filters
{
    public class ValidationFilter:IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if(!context.ModelState.IsValid)
            {
                var data = new BadRequestObjectResult(context.ModelState);
                var response = new Response(data.Value, "Algunos datos no son validos.");
                context.Result = new BadRequestObjectResult(response);
                return;
            }
            await next();
        }
    }
}
