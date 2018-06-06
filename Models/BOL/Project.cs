using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BOL
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ProjectName { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        //Navigation Property
        public ICollection<Member> Members { get; set; }

    }
}
