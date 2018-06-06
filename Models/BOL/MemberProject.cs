using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BOL
{
    public class MemberProject
    {
        public int Id { get; set; }
        public int Title { get; set; }
        public string ProjectName { get; set; }
        public int ProjectId { get; set; }
        public int FirstName { get; set; }
        public int LastName { get; set; }
    }
}
