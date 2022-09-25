using APP.STOREHOUSE.WEBAPI.Data;
using APP.STOREHOUSE.WEBAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public IEnumerable<Product> Get([FromQuery] string productname)
        {
            StorehouseContext context = new StorehouseContext();
            var result = context.Products.Where(x => x.Name.Contains(productname)).ToArray();
            return result;
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] Product product)
        {
        }

        // PUT api/<ProductsController>
        [HttpPut()]
        public void Put([FromBody] Product product)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id:guid}")]
        public void Delete(Guid id)
        {
            StorehouseContext context = new StorehouseContext();
            var product = context.Products.Find(id);
            if (product != null)
            {
                context.Products.Remove(product);
            }
            context.SaveChanges();
        }
    }
}
