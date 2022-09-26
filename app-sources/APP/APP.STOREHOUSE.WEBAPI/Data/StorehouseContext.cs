using APP.STOREHOUSE.WEBAPI.Models;
using APP.STOREHOUSE.WEBAPI.Options;
using Microsoft.Extensions.Options;
using System.Data.Entity;

namespace APP.STOREHOUSE.WEBAPI.Data
{
    public class StorehouseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public StorehouseContext(IOptions<DatabaseConnectionOptions> options)
            : base(options.Value.ConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().ToTable("PRODUCT", "STOREHOUSE");
            modelBuilder.Build(this.Database.Connection);
        }
    }
}
