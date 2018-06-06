using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.BOL;

namespace Models.DAL
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private MentorsContext _repoContext;
        private IProjectRepository _project;
        private IMemebrRepository _memeber;

        public IProjectRepository Project
        {
            get
            {
                if (_project == null)
                {
                    _project = new ProjectRepository(_repoContext);
                }

                return _project;
            }
        }

        public IMemebrRepository Memebr
        {
            get
            {
                if (_memeber == null)
                {
                    _memeber = new MemeberRepository(_repoContext);
                }

                return _memeber;
            }
        }

        public RepositoryWrapper(MentorsContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
    }
}
