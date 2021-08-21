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
    public class EstadoController: ApiController
    {
        private readonly IEstadoService _estadoService;
        public EstadoController(IEstadoService estadoService, ILogger<Controller> logger) : base(logger)
        {
            _estadoService = estadoService;
        }


        [HttpGet("GetAllEstado")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _estadoService.GetAll();
            return Ok(result);
        }
    }
}
