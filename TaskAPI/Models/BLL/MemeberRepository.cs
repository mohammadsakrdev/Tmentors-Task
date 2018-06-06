using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAPI.Models.BOL;

namespace TaskAPI.Models.DAL
{
    public class MemeberRepository : RepositoryBase<Member>, IMemebrRepository
    {
        public MemeberRepository(MemberProjectContext memberProjectContext)
            : base(memberProjectContext)
        {
        }
    }
}
