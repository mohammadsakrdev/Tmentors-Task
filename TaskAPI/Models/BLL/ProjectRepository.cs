using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAPI.Models.BOL;

namespace TaskAPI.Models.DAL
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(MemberProjectContext memberProjectContext)
            : base(memberProjectContext)
        {
        }

    }
}
