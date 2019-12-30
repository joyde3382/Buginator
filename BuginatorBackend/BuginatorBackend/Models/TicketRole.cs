using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuginatorBackend.Models
{
    public enum Type {Creator, Follower};
    public class TicketRole
    {
        public int Id { get; set; }
        public Type type{ get; set; }

        public virtual User user { get; set; }
        public virtual Ticket ticket { get; set; }
    }
}
