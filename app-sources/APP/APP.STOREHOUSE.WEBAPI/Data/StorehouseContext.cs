using APP.STOREHOUSE.WEBAPI.Models;
using System.Data.Entity;

namespace APP.STOREHOUSE.WEBAPI.Data
{
    public class StorehouseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public StorehouseContext()
            : base(@"Data Source=DESKTOP-K1GCKQ5\MSSQLSERVER2017;Initial Catalog=TestDb;User ID=TestDbLogin;Password=TestDbDevelop1;")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
