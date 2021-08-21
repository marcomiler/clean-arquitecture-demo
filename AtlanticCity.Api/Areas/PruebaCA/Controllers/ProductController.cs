using AtlanticCity.Api.Base;
using AtlanticCity.Core.DTOs.PruebaCA;
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
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService , ILogger<Controller> logger) : base(logger)
        {
            _productService = productService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productInsertDTO"></param>
        /// <returns></returns>
        [HttpPost("InsertProduct")]
        public async Task<IActionResult> InsertProduct(ProductInsertDTO productInsertDTO)
        {
            var result = await _productService.Insert(productInsertDTO);
            return Ok(result);
        }
    }
}
