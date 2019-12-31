using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class UserHasTicketDto
    {
        public Guid? UserHasTicketId { get; set; }
        public string UserTicketRole { get; set; }
        public Guid UserUserId { get; set; }
        public Guid TicketTicketId { get; set; }

        public virtual TicketDto TicketTicket { get; set; }
        public virtual UserDto UserUser { get; set; }
    }
}
