using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.BOL;

namespace Models.DAL
{
    public class MemeberRepository : RepositoryBase<Memeber>, IMemebrRepository
    {
        public MemeberRepository(MentorsContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
