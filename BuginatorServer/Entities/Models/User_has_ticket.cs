using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("user_has_ticket")]
    public class User_has_ticket
    {
        public Guid User_has_ticketId { get; set; }

        [Required(ErrorMessage = "UserTicketRole is required")]
        [StringLength(60, ErrorMessage = "UserTicketRole can't be longer than 60 characters")]
        public string UserTicketRole{ get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey(nameof(Ticket))]
        public Guid TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
