using HeBoGuoShi.DBModels;
using HeBoGuoShi.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HeBoGuoShi.DBModels
{
    public class HeboContext : ApplicationDbContext
    {
        public HeboContext()
        {

        }

        public DbSet<OwnerProduct> OwnerProducts { get; set; }
        public DbSet<OwnerProductImage> OwnerProductImages { get; set; }
        public DbSet<SellerProduct> SellerProducts { get; set; }
        public DbSet<BuyerProduct> BuyerProducts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}