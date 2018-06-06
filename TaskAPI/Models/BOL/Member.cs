using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAPI.Models.BOL
{
    public class Member
    {
        [Key]
        public int Id { get; set; }

        public int ProjectId { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Title { get; set; }

        // Navigation Property
        public Project Project { get; set; }

    }
}
