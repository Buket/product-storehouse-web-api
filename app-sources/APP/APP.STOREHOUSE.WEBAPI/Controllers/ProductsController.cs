using APP.STOREHOUSE.WEBAPI.Data;
using APP.STOREHOUSE.WEBAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APP.STOREHOUSE.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get([FromQuery] string productname, [FromServices] StorehouseContext context)
        {
            var result = context.Products.Where(x => x.Name.Contains(productname)).ToArray();
            return this.Ok(result);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            return this.Ok();
        }

        // PUT api/<ProductsController>
        [HttpPut()]
        public IActionResult Put([FromBody] Product product)
        {
            return this.Ok();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id:guid}")]
        public IActionResult Delete([FromRoute]Guid id, [FromServices] StorehouseContext context)
        {
            var product = context.Products.Find(id);
            if (product != null)
            {
                context.Products.Remove(product);
            }
            context.SaveChanges();

            return this.Ok();
        }
    }
}
