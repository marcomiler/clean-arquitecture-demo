using AtlanticCity.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace AtlanticCity.Api.Core
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<Controller> _logger;

        /// <summary>
        /// ExceptionFilter
        /// </summary>
        public GlobalExceptionFilter(ILogger<Controller> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            _logger.LogError(default(EventId), context.Exception, context.Exception.Message);

            Response response = new Response(null, context.Exception.Message);
            context.HttpContext.Response.StatusCode = 400;
            context.Result = new JsonResult(response);
            base.OnException(context); 
        }
    }
}
