using APP.STOREHOUSE.WEBAPI.Models;
using APP.STOREHOUSE.WEBAPI.Options;
using CodeFirstStoreFunctions;
using Microsoft.Extensions.Options;
using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace APP.STOREHOUSE.WEBAPI.Data
{
    public class StorehouseContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }

        public StorehouseContext()
        {
        }

        internal StorehouseContext(IOptions<DatabaseConnectionOptions> options)
            : base(options.Value.ConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("STOREHOUSE");
            modelBuilder.Entity<Product>().ToTable("PRODUCT", "STOREHOUSE");
            modelBuilder.ComplexType<ProductInfo>();
            modelBuilder.Conventions.Add(new FunctionsConvention<StorehouseContext>("STOREHOUSE"));
        }

        [DbFunction("StorehouseContext", "FIND_PRODUCT")]
        [DbFunctionDetails(DatabaseSchema = "STOREHOUSE")]
        public IQueryable<ProductInfo> FindProduct(string productName, string productversionName = null, float? minimalVolume = null, float? maximalVolume = null)
        {
            var productNameParam = new ObjectParameter("product_name", typeof(string)) { Value = (object)productName };
            var productversionNameParam = new ObjectParameter("productversion_name", typeof(string)) { Value = (object)productversionName ?? DBNull.Value };
            var minimalVolumeParam = new ObjectParameter("minimal_volume", typeof(float)) { Value = (object)minimalVolume ?? DBNull.Value };
            var maximalVolumeParam = new ObjectParameter("maximal_volume", typeof(float)) { Value = (object)maximalVolume ?? DBNull.Value };

            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<ProductInfo>("[StorehouseContext].[FIND_PRODUCT](@product_name, @productversion_name, @minimal_volume, @maximal_volume)", productNameParam, productversionNameParam, minimalVolumeParam, maximalVolumeParam);
        }
    }
}
