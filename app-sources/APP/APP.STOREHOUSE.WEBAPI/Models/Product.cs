using System;

namespace APP.STOREHOUSE.WEBAPI.Models
{
    public class Product
    {
        internal const string ProductName = "Продукт";

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
