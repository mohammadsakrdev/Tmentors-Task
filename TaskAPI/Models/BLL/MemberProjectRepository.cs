using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TaskAPI.Models.BOL;
using TaskAPI.Models.DAL;

namespace TaskAPI.Models.BLL
{
    public class MemberProjectRepository : RepositoryBase<MemberProject>, IMemberProjectRepository
    {
        public MemberProjectRepository(MemberProjectContext memberProjectContext)
            : base(memberProjectContext)
        {
        }

        public override IQueryable<MemberProject> GetAll()
        {
            var members = from p in this.MemberProjectContext.Projects
                         join m in this.MemberProjectContext.Members
                         on p.Id equals m.ProjectId
                         select new MemberProject
                         {
                             Id = m.Id,
                             FirstName = m.FirstName,
                             LastName = m.LastName,
                             Title = m.Title,
                             ProjectName = p.ProjectName,
                             ProjectId = p.Id
                         };
            return members;
        }

        public MemberProject GetMemberProjectById(int Id)
        {
            var members = from p in this.MemberProjectContext.Projects
                          join m in this.MemberProjectContext.Members
                          on p.Id equals m.ProjectId
                          select new MemberProject
                          {
                              Id = m.Id,
                              FirstName = m.FirstName,
                              LastName = m.LastName,
                              Title = m.Title,
                              ProjectName = p.ProjectName,
                              ProjectId = p.Id
                          };
            return members.SingleOrDefault();
        }

        public IQueryable<MemberProject> GetProjectMembers(int Id)
        {
            var members = from p in this.MemberProjectContext.Projects
                          join m in this.MemberProjectContext.Members
                          on p.Id equals m.ProjectId
                          where m.ProjectId == Id
                          select new MemberProject
                          {
                              Id = m.Id,
                              FirstName = m.FirstName,
                              LastName = m.LastName,
                              Title = m.Title,
                              ProjectName = p.ProjectName,
                              ProjectId = p.Id
                          };
            return members;
        }
    }
}