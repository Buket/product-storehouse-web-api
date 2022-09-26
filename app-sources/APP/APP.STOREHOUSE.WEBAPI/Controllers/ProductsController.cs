using APP.STOREHOUSE.WEBAPI.Exceptions;
using APP.STOREHOUSE.WEBAPI.Models;
using APP.STOREHOUSE.WEBAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APP.STOREHOUSE.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get([FromQuery] string productname, [FromServices] ProductService productService)
        {
            return this.Ok(productService.Get(productname));
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product, [FromServices] ProductService productService)
        {
            return this.Ok(productService.CreateProduct(product));
        }

        // PUT api/<ProductsController>
        [HttpPut()]
        public IActionResult Put([FromBody] Product product, [FromServices] ProductService productService)
        {
            productService.UpdateProduct(product);
            return this.Ok();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id:guid}")]
        public IActionResult Delete([FromRoute]Guid id, [FromServices] ProductService productService)
        {
            productService.DeleteProduct(id);
            return this.Ok();
        }
    }
}
