using Microsoft.EntityFrameworkCore;
using Stores.Data.Entities;
using System.Reflection;

namespace Stores.Data.Context
{
    public class StoresDBContext :DbContext
    {
            
        public StoresDBContext(DbContextOptions<StoresDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrand { get; set; }
        public DbSet<ProductTypes> ProductType { get; set; }


    }
}
