using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuginatorBackend.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime createdDate { get; set; }
        public string description { get; set; }
        public virtual Project project { get; set; }

        public virtual List<TicketRole> ticketRoles { get; set; } = new List<TicketRole>();
    }
}
