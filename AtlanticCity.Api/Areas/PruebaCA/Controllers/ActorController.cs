using AtlanticCity.Api.Base;
using AtlanticCity.Core.Interfaces.IServices.PruebaCA;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtlanticCity.Api.Areas.PruebaCA.Controllers
{
    [Area("PruebaCA")]
    [Route("[area]/api/[controller]")]
    public class ActorController : ApiController
    {
        private readonly IActorService _actorService;
        public ActorController(IActorService actorService, ILogger<Controller> logger) : base(logger)
        {
            _actorService = actorService;
        }

       
        [HttpGet("GetAllActor")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _actorService.GetAll();
            return Ok(result);
        }
    }


}
