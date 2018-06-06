using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskAPI.Models.BLL;

namespace TaskAPI.Models.DAL
{
    public class UnitOfWork : IDisposable
    {
        private MemberProjectContext _repoContext = new MemberProjectContext();
        private IProjectRepository _project;
        private IMemebrRepository _member;
        private IMemberProjectRepository _memberProject;


        public IMemberProjectRepository MemberProject
        {
            get
            {
                if (_memberProject == null)
                {
                    _memberProject = new MemberProjectRepository(_repoContext);
                }

                return _memberProject;
            }
        }
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

        public IMemebrRepository Member
        {
            get
            {
                if (_member == null)
                {
                    _member = new MemeberRepository(_repoContext);
                }

                return _member;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _repoContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}