using APP.STOREHOUSE.WEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace APP.STOREHOUSE.WEBAPI.TESTS
{
    internal class ProductEqualityComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product? x, Product? y)
        {
            if (x is null || y is null)
            {
                return false;
            }

            if (ReferenceEquals(x,y))
            {
                return true;
            }

            return x.Id == y.Id &&
                x.Name == y.Name &&
                x.Description == y.Description;
        }

        public int GetHashCode([DisallowNull] Product obj)
        {
            return HashCode.Combine(obj.Id, obj.Name, obj.Description);
        }
    }
}
