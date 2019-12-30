using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("project")]
    public partial class Project
    {
        public Project()
        {
            Ticket = new HashSet<Ticket>();
            UserHasProject = new HashSet<UserHasProject>();
        }

        public Guid ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreation { get; set; }

        public virtual ICollection<Ticket> Ticket { get; set; }
        public virtual ICollection<UserHasProject> UserHasProject { get; set; }
    }
}
