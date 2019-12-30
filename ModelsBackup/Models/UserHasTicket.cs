using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("userHasTicket")]
    public partial class UserHasTicket
    {
        public Guid? UserHasTicketId { get; set; }
        public string UserTicketRole { get; set; }
        public Guid UserUserId { get; set; }
        public Guid TicketTicketId { get; set; }

        public virtual Ticket TicketTicket { get; set; }
        public virtual User UserUser { get; set; }
    }
}
