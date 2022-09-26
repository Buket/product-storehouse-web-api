using APP.STOREHOUSE.WEBAPI.Data;
using APP.STOREHOUSE.WEBAPI.Exceptions;
using APP.STOREHOUSE.WEBAPI.Models;
using APP.STOREHOUSE.WEBAPI.Services;
using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace APP.STOREHOUSE.WEBAPI.TESTS
{
    [TestClass]
    public class ProductServiceUpdateTest
    {
        private ProductService _productService;
        private StorehouseContext _storehouseContext;
        private Product _storedProduct;
        private Mock<DbSet<Product>> _productsDbSet;

        [TestInitialize]
        public void Setup()
        {
            _storehouseContext = Mock.Of<StorehouseContext>();
            _storedProduct = new Product()
            {
                Id = Guid.Parse("e63e2449-c4c5-484e-9330-f8a101909e68"),
                Name = "item number #2",
                Description = "some long descrption two"
            };


            _productsDbSet = new Mock<DbSet<Product>>();
            _productsDbSet.Setup(x => x.Find(It.Is<Guid>(guid => guid.Equals(Guid.Parse("e63e2449-c4c5-484e-9330-f8a101909e68"))))).Returns(_storedProduct);
            _productsDbSet.Setup(x => x.Remove(_storedProduct)).Verifiable();
            _productsDbSet.Setup(x => x.Add(It.IsAny<Product>())).Verifiable();
            Mock.Get<StorehouseContext>(_storehouseContext).Setup(x => x.Products).Returns(_productsDbSet.Object);

            _productService = new ProductService(_storehouseContext);
        }

        [TestMethod]
        public void Update__Success()
        {
            var comparer = new ProductEqualityComparer();
            var fixture = new Fixture();
            fixture.Customize<Product>(x => x.With(property => property.Id, Guid.Parse("e63e2449-c4c5-484e-9330-f8a101909e68")));
            var product = fixture.Create<Product>();
            
            _productService.UpdateProduct(product);

            _productsDbSet.Verify();
        }

        [TestMethod]
        public void Update__ThrowException()
        {
            var comparer = new ProductEqualityComparer();
            var fixture = new Fixture();
            fixture.Customize<Product>(x => x.With(property => property.Id, Guid.Parse("3d5c0436-bce3-438f-aeba-dd5c6c8ebe98")));
            var product = fixture.Create<Product>();

            var exception = Assert.ThrowsException<NotFoundException>(() => _productService.UpdateProduct(product));

            Assert.IsTrue(exception.Errors.Any());
        }
    }
}