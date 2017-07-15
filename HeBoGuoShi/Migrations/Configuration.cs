using HeBoGuoShi.DBModels;
using HeBoGuoShi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;

namespace HeBoGuoShi.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<HeboContext>
    {

        private readonly RoleManager<IdentityRole> _roleManager;

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            _roleManager = new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(new ApplicationDbContext()));
        }

        protected override void Seed(HeboContext context)
        {
            var exist = _roleManager.RoleExists("Owner");

            if (!exist)
            {
                var owner = new IdentityRole()
                {
                    Name = "Owner"
                };

                _roleManager.Create(owner);
            }


            exist = _roleManager.RoleExists("Seller");

            if (!exist)
            {
                var seller = new IdentityRole()
                {
                    Name = "Seller"
                };

                _roleManager.Create(seller);
            }

            exist = _roleManager.RoleExists("Buyer");

            if (!exist)
            {
                var seller = new IdentityRole()
                {
                    Name = "Buyer"
                };

                 _roleManager.Create(seller);
            }
        }
    }
}
