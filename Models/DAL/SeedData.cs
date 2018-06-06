
using System;
using System.Linq;
using Models.BOL;

namespace Models.DAL
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MentorsContext(
                serviceProvider.GetRequiredService<DbContextOptions<MentorsContext>>()))
            {

                // Look for any Projects.
                if (context.Projects.Any())
                {
                    return;   // DB has been seeded
                }

                context.Projects.AddRange(
                    new Project { Name = "CRM Application", CreatedDate = DateTime.Parse("2005-09-01"), StartDate = DateTime.Parse("2005-09-01"), EndDate = DateTime.Parse("2005-09-01") },
                    new Project { Name = "MVC Application", CreatedDate = DateTime.Parse("2002-09-01"), StartDate = DateTime.Parse("2005-09-01"), EndDate = DateTime.Parse("2005-09-01") },
                    new Project { Name = "Angular Application", CreatedDate = DateTime.Parse("2003-09-01"), StartDate = DateTime.Parse("2005-09-01"), EndDate = DateTime.Parse("2005-09-01") },
                    new Project { Name = "React Application", CreatedDate = DateTime.Parse("2002-09-01"), StartDate = DateTime.Parse("2005-09-01"), EndDate = DateTime.Parse("2005-09-01") }
                );

                context.SaveChanges();
            }

        }
    }
}
