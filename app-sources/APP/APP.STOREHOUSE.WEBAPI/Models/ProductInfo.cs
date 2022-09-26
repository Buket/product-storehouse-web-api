using System;

namespace APP.STOREHOUSE.WEBAPI.Models
{
    public class ProductInfo
    {
        public Guid ProductVersionId { get; set; }
        public string ProductName { get; set; }
        public string ProductVersionName { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Length { get; set; }
    }
}
