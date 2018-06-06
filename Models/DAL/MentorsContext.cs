
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.BOL;

namespace Models.DAL
{
    public class MentorsContext : DbContext
    {
        public MentorsContext(DbContextOptions<MentorsContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Memeber> Memebers { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Project>().ToTable("Project");
        //    modelBuilder.Entity<Memeber>().ToTable("Memeber");
        //}
    }
}
