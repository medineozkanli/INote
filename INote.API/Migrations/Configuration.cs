namespace INote.API.Migrations
{
    using INote.API.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<INote.API.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(INote.API.Models.ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var user = new ApplicationUser
                {
                    UserName = "ozknlimedine@gmail.com",
                    Email = "ozknlimedine@gmail.com",
                    EmailConfirmed = true
                };
                userManager.Create(user, "Ankara1.");
      
                context.Notes.Add(new Note
                {
                    AuthorId = user.Id,
                    Title = "Sample Note 1",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla facilisis venenatis semper. Duis nec velit pharetra, iaculis odio in, semper orci. Quisque lobortis, nibh vel imperdiet mollis, sem tortor tincidunt ex, eu aliquet quam arcu a odio. Suspendisse accumsan ipsum in nisi mollis, sed pretium orci blandit. ",
                    CreatedTime = DateTime.Now
                });

                context.Notes.Add(new Note
                {
                    AuthorId =user.Id,
                    Title = "Sample Note 2",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla facilisis venenatis semper. Duis nec velit pharetra, iaculis odio in, semper orci. Quisque lobortis, nibh vel imperdiet mollis, sem tortor tincidunt ex, eu aliquet quam arcu a odio. Suspendisse accumsan ipsum in nisi mollis, sed pretium orci blandit. ",
                    CreatedTime = DateTime.Now.AddMinutes(10)
                });
              
            }

        }
    }
}
