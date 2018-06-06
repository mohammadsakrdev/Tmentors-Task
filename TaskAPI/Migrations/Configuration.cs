namespace TaskAPI.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TaskAPI.Models.BOL;

    internal sealed class Configuration : DbMigrationsConfiguration<TaskAPI.Models.DAL.MemberProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TaskAPI.Models.DAL.MemberProjectContext context)
        {
            var projects = new List<Project>
            {
                new Project { ProjectName = "CRM Application", CreateDate = DateTime.Parse("2005-09-01"), StartDate = DateTime.Parse("2005-09-01"), EndDate = DateTime.Parse("2005-09-01") },
                new Project { ProjectName = "MVC Application", CreateDate = DateTime.Parse("2002-09-01"), StartDate = DateTime.Parse("2005-09-01"), EndDate = DateTime.Parse("2005-09-01") },
                new Project { ProjectName = "Angular Application", CreateDate = DateTime.Parse("2003-09-01"), StartDate = DateTime.Parse("2005-09-01"), EndDate = DateTime.Parse("2005-09-01") },
                new Project { ProjectName = "React Application", CreateDate = DateTime.Parse("2002-09-01"), StartDate = DateTime.Parse("2005-09-01"), EndDate = DateTime.Parse("2005-09-01") }
            };

            projects.ForEach(p => context.Projects.Add(p));
            context.SaveChanges();


            var members = new List<Member>
            {
                new Member { FirstName = "Mohammad 1", LastName = "Ahmed 1", Title = "SW Developer", ProjectId = 1 },
                new Member { FirstName = "Mohammad 2", LastName = "Ahmed 2", Title = "SW Developer", ProjectId = 1 },
                new Member { FirstName = "Mohammad 3", LastName = "Ahmed 3", Title = "SW Developer", ProjectId = 2 },
                new Member { FirstName = "Mohammad 4", LastName = "Ahmed 4", Title = "SW Developer", ProjectId = 2 },
                new Member { FirstName = "Mohammad 5", LastName = "Ahmed 5", Title = "SW Developer", ProjectId = 3 },
                new Member { FirstName = "Mohammad 6", LastName = "Ahmed 6", Title = "SW Developer", ProjectId = 3 },
                new Member { FirstName = "Mohammad 7", LastName = "Ahmed 7", Title = "SW Developer", ProjectId = 4 },
                new Member { FirstName = "Mohammad 8", LastName = "Ahmed 8", Title = "SW Developer", ProjectId = 4 },
              };

            members.ForEach(m => context.Members.Add(m));
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
