using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuginatorBackend.Models
{
    public class Project
    {
        public Guid projectId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(60, ErrorMessage = "Title can't be longer than 60 characters")]
        public string title { get; set; }
        public DateTime createdDate { get; set; }
        public string description { get; set; }

       
        public virtual ICollection<UserToProject> userToProjects { get; set; }

        [ForeignKey(nameof(Ticket))]
        public virtual ICollection<Ticket> tickets { get; set; }
    }
}
