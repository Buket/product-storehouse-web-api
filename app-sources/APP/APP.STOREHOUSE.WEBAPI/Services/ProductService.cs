using APP.STOREHOUSE.WEBAPI.Data;
using APP.STOREHOUSE.WEBAPI.Exceptions;
using APP.STOREHOUSE.WEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APP.STOREHOUSE.WEBAPI.Services
{
    public class ProductService
    {
        private readonly StorehouseContext context;

        public ProductService(StorehouseContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> Get(string productname)
        {
            return context.Products.Where(x => x.Name.Contains(productname)).ToArray();
        }

        public IEnumerable<ProductInfo> FindProduct(string productname, string productversionname = null, float? mixvolume = null, float? maxvolume = null)
        {
            return context.FindProduct(productname, productversionname, mixvolume, maxvolume).ToArray();
        }

        public Guid Create(Product product)
        {
            using var transaction = context.Database.BeginTransaction(System.Data.IsolationLevel.Serializable);
            if (product.Id == default)
            {
                product.Id = Guid.NewGuid();
            }
            context.Products.Add(product);
            context.SaveChanges();
            transaction.Commit();

            return product.Id;
        }

        public void Update(Product product)
        {
            using var transaction = context.Database.BeginTransaction();
            var storedProduct = context.Products.Find(product.Id) ?? throw new NotFoundException(Product.ProductName, product.Id);
            context.Products.Remove(storedProduct);
            context.Products.Add(product);
            context.SaveChanges();
            transaction.Commit();
        }

        public void Delete(Guid id)
        {
            using var transaction = context.Database.BeginTransaction();
            var product = context.Products.Find(id) ?? throw new NotFoundException(Product.ProductName, id);
            context.Products.Remove(product);
            context.SaveChanges();
            transaction.Commit();
        }
    }
}
