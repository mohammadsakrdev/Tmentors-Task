using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAPI.Models.BOL
{
    public class MemberProject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ProjectName { get; set; }
        public int ProjectId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + ", " + LastName;
            }
        }
    }
}
