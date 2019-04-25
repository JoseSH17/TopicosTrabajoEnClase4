namespace EstacionamientoWeb.Migrations
{
    using EstacionamientoWeb.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EstacionamientoWeb.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "EstacionamientoWeb.Models.ApplicationDbContext";
        }

        protected override void Seed(EstacionamientoWeb.Models.ApplicationDbContext context)
        {
            if (!context.Users.Any(u => u.UserName == "jose@trabajo4.com"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = "jose@trabajo4.com" };
                var user2 = new ApplicationUser { UserName = "mario@trabajo4.com" };
                var user3 = new ApplicationUser { UserName = "luis@trabajo4.com" };
                var user4 = new ApplicationUser { UserName = "kevin@trabajo4.com" };

                userManager.Create(user, "password");
                roleManager.Create(new IdentityRole { Name = "Admin" });
                userManager.AddToRole(user.Id, "Admin");

                userManager.Create(user2, "password");
                userManager.AddToRole(user2.Id, "Admin");

                userManager.Create(user3, "password");
                roleManager.Create(new IdentityRole { Name = "Operario" });
                userManager.AddToRole(user3.Id, "Operario");

                userManager.Create(user4, "password");
                userManager.AddToRole(user4.Id, "Operario");

            }
        }
    }
}
