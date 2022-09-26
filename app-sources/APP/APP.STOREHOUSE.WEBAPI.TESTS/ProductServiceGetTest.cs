using APP.STOREHOUSE.WEBAPI.Data;
using APP.STOREHOUSE.WEBAPI.Models;
using APP.STOREHOUSE.WEBAPI.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace APP.STOREHOUSE.WEBAPI.TESTS
{
    [TestClass]
    public class ProductServiceGetTest
    {
        private ProductService _productService;
        private StorehouseContext _storehouseContext;
        private IEnumerable<Product> _products;


        [TestInitialize]
        public void Setup()
        {
            _storehouseContext = Mock.Of<StorehouseContext>();
            _products = new Product[] {
                new Product() {
                    Id = Guid.Parse("3b4526e0-fb88-4487-9367-df9953cc772a"),
                    Name = "item number #1",
                    Description = "some long descrption"
                },
                new Product() {
                    Id = Guid.Parse("e63e2449-c4c5-484e-9330-f8a101909e68"),
                    Name = "item number #2",
                    Description = "some long descrption two"
                }
            };


            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(_products.AsQueryable().Provider);
            mockSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(_products.AsQueryable().Expression);
            mockSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(_products.AsQueryable().ElementType);
            mockSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(_products.AsQueryable().GetEnumerator());

            Mock.Get<StorehouseContext>(_storehouseContext).Setup(x => x.Products).Returns(mockSet.Object);

            _productService = new ProductService(_storehouseContext);
        }

        [TestMethod]
        public void TestMethodGet()
        {
            var comparer = new ProductEqualityComparer();
            
            var result = _productService.Get("#1").FirstOrDefault();
            
            Assert.IsNotNull(result);
            Assert.IsTrue(comparer.Equals(result, _products.First()));
        }
    }
}