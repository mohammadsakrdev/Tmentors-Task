using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskAPI.Models.BOL;

namespace TaskAPI.Models.DAL
{
    public interface IMemberProjectRepository : IRepositoryBase<MemberProject>
    {
        MemberProject GetMemberProjectById(int Id);
        IQueryable<MemberProject> GetProjectMembers(int Id);
    }
}