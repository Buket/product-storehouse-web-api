﻿using APP.STOREHOUSE.WEBAPI.Data;
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

        public Guid CreateProduct(Product product)
        {
            using (context.Database.BeginTransaction())
            {
                if (product.Id == default)
                {
                    product.Id = Guid.NewGuid();
                }
                context.Products.Add(product);
                context.SaveChanges();
            }

            return product.Id;
        }

        public void UpdateProduct(Product product)
        {
            using (context.Database.BeginTransaction())
            {
                var storedProduct = context.Products.Find(product.Id) ?? throw new NotFoundException(Product.ProductName, product.Id);
                context.Products.Remove(storedProduct);
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void DeleteProduct(Guid id)
        {
            using (context.Database.BeginTransaction())
            {
                var product = context.Products.Find(id) ?? throw new NotFoundException(Product.ProductName, id);
                if (product != null)
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
            }
        }
    }
}
