namespace Plagiarism.DataLayer.Run.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Plagiarism.DataLayer.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Plagiarism.DataLayer.Models.MainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Plagiarism.DataLayer.Models.MainContext context)
        {
            //Class @class = new Class
            //{
            //    ClassName = "X-2"
            //};
            //context.Classes.Add(@class);
            //Assignment assignment = new Assignment
            //{
            //    AssignmentName = "English Composition 2"
            //};
            //context.Assignments.Add(assignment);
            //CommonAppUser admin = new CommonAppUser
            //{
            //    UserName = "Admin",
            //    FullName = "System Administrator",
            //    Email = "ghulamcyber@hotmail.com"
                
            //};
            //context.SaveChanges();

            //RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(context);
            //RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(roleStore);
            //roleManager.Create(new IdentityRole
            //{
            //    Name = "Admin"
            //});
            //roleManager.Create(new IdentityRole
            //{
            //    Name = "Student"
            //});
            //UserStore<CommonAppUser> userStore = new UserStore<CommonAppUser>(context);
            //UserManager<CommonAppUser> userManager = new UserManager<CommonAppUser>(userStore);
            //userManager.Create(admin, "future");
            //userManager.AddToRole(admin.Id, "Admin");

        }
    }
}
