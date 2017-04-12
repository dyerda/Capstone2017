namespace Final_Project.ApplicationContextMigrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Final_Project.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"ApplicationContextMigrations";
        }

        protected override void Seed(Final_Project.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            //  This method will be called after migrating to the latest version.
            if (!(context.Users.Any(u => u.UserName == "student@sheridancollege.ca")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "student@sheridancollege.ca", PhoneNumber = "9055551234" };
                userManager.Create(userToInsert, "student20!4");
                userManager.AddToRole(userToInsert.Id, "Admin");
            }

        }
    }
}
