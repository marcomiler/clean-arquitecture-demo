using AtlanticCity.Api.Base;
using AtlanticCity.Core.Interfaces.IServices.PruebaCA;
using Microsoft.AspNetCore.Http;
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
    public class CategoryController : ApiController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService, ILogger<Controller> logger) : base(logger)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        
        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetAll();
            return Ok(result);
        }
    }
}
