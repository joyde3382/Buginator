using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Ticket
    {
        public Guid TicketId { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime DateOfCreation { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(Project))]
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public virtual ICollection<User_has_ticket> TicketRoles { get; set; }
    }
}
