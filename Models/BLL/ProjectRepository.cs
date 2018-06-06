using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.BOL;

namespace Models.DAL
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(MentorsContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
