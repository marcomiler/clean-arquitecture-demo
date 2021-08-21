using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtlanticCity.Api.Base
{
    [Produces("application/json")]
    [ApiController]
    public class ApiController : Controller
    {
        public ApiController(ILogger<Controller> logger)
        {
        }
    }
}
