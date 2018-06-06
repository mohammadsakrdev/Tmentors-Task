using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.DAL
{
    public interface IRepositoryWrapper
    {
        IProjectRepository Project { get; }
        IMemebrRepository Memebr { get; }
    }
}
