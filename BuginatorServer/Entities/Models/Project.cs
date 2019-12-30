using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("project")]
    public class Project
    {
        public Guid ProjectId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(60, ErrorMessage = "Title can't be longer than 60 characters")]
        public string Title { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Description { get; set; }

       
        public virtual ICollection<User_has_project> User_has_projects { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
