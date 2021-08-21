using AtlanticCity.Core.Interfaces.ICore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace AtlanticCity.Api.Core
{
    public class ControllerFilterAttribute: Attribute, IActionFilter
    {
        private readonly ILogger<Controller> _logger;

        private readonly ISettings _settings;

        public ControllerFilterAttribute(ILogger<Controller> logger, ISettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

    }
}
