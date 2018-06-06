using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BOL
{
    public class Member
    {
        [Key]
        public int Id { get; set; }

        public int ProjectId { get; set; }

        [Required]
        public int FirstName { get; set; }
        public int LastName { get; set; }

        public int Title { get; set; }

        // Navigation Property
        public Project Project { get; set; }

    }
}
