using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Plagiarism.DataLayer.Models;
namespace Plagiarism.DataLayer.Run
{
    class Program
    {
        static void AddStudentToClassAndAssignATask()
        {
            try
            {
                using (MainContext context = new MainContext())
                {
                    Class @class = context.Classes.FirstOrDefault(x => x.ClassName.Equals("X-2",StringComparison.InvariantCultureIgnoreCase));
                    Assignment assignment = context.Assignments.FirstOrDefault(x => x.AssignmentName.Equals("English Composition 2", StringComparison.InvariantCultureIgnoreCase));
                    CommonAppUser student = new CommonAppUser
                    {
                        UserName = "mirzaevolution",
                        Email = "ghulamcyber@hotmail.com",
                        FullName = "Mirza Ghulam Rasyid",
                        Class = @class
                    };
                    student.Assignments.Add(assignment);

                    UserStore<CommonAppUser> userStore = new UserStore<CommonAppUser>(context);
                    UserManager<CommonAppUser> userManager = new UserManager<CommonAppUser>(userStore);
                    
                    var result = userManager.Create(student, "future30");

                    if (result.Succeeded)
                    {
                        userManager.AddToRole(student.Id, "Student");
                        Console.WriteLine("Student has been created");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                            Console.WriteLine(item);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        static void CreateAdmin()
        {
            try
            {
                using (MainContext context = new MainContext())
                {
                    Class @class = context.Classes.FirstOrDefault(x => x.ClassName.Equals("X-2", StringComparison.InvariantCultureIgnoreCase));
                    Assignment assignment = context.Assignments.FirstOrDefault(x => x.AssignmentName.Equals("English Composition 2", StringComparison.InvariantCultureIgnoreCase));
                    CommonAppUser student = new CommonAppUser
                    {
                        UserName = "admin",
                        Email = "ghulamcyber@hotmail.com",
                        FullName = "Administrator"
                    };

                    UserStore<CommonAppUser> userStore = new UserStore<CommonAppUser>(context);
                    UserManager<CommonAppUser> userManager = new UserManager<CommonAppUser>(userStore);

                    var result = userManager.Create(student, "future123");

                    if (result.Succeeded)
                    {
                        userManager.AddToRole(student.Id, "Admin");
                        Console.WriteLine("Admin has been created");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                            Console.WriteLine(item);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        static void QueryByUser()
        {
            try
            {
                using (MainContext context = new MainContext())
                {
                    UserStore<CommonAppUser> userStore = new UserStore<CommonAppUser>(context);
                    UserManager<CommonAppUser> userManager = new UserManager<CommonAppUser>(userStore);
                    CommonAppUser user = userManager.FindByName("mirzaevolution");
                    if (user != null)
                    {
                        var assignments = user.Assignments.ToList();
                        var @class = user.Class;
                        var roles = user.Roles.ToList();

                    }
                    else
                    {
                        Console.WriteLine("User not found");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        static void Main(string[] args)
        {
            //CreateAdmin();
            //AddStudentToClassAndAssignATask();
            QueryByUser();
            Console.ReadLine();
        }
    }
}
