using APP.STOREHOUSE.WEBAPI.Exceptions;
using APP.STOREHOUSE.WEBAPI.Models;
using APP.STOREHOUSE.WEBAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APP.STOREHOUSE.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get(
            [FromServices] ProductService productService,
            [FromQuery][Required] string productname,
            [FromQuery] string productversionname = null,
            [FromQuery] float? minVolume = null,
            [FromQuery] float? maxVolume = null)
        {
            //return this.Ok(productService.Get(productname));
            return this.Ok(productService.FindProduct(productname, productversionname, minVolume, maxVolume));
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product, [FromServices] ProductService productService)
        {
            return this.Ok(productService.Create(product));
        }

        // PUT api/<ProductsController>
        [HttpPut()]
        public IActionResult Put([FromBody] Product product, [FromServices] ProductService productService)
        {
            productService.Update(product);
            return this.Ok();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id:guid}")]
        public IActionResult Delete([FromRoute]Guid id, [FromServices] ProductService productService)
        {
            productService.Delete(id);
            return this.Ok();
        }
    }
}
