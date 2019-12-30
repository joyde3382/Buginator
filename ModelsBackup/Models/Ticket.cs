using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("ticket")]
    public partial class Ticket
    {
        public Ticket()
        {
            UserHasTicket = new HashSet<UserHasTicket>();
        }

        public Guid TicketId { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Title { get; set; }
        public Guid ProjectProjectId { get; set; }

        public virtual Project ProjectProject { get; set; }
        public virtual ICollection<UserHasTicket> UserHasTicket { get; set; }
    }
}
