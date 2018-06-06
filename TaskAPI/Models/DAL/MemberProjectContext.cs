
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TaskAPI.Models.BOL;

namespace TaskAPI.Models.DAL
{
    public class MemberProjectContext : DbContext
    {
        public MemberProjectContext() : base("name=MemberProjectContext")
        {
        }

        public DbSet<Member> Members { get; set; }

        public DbSet<Project> Projects { get; set; }
    }
}

