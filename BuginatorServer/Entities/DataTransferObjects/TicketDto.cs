using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class TicketDto
    {
        public Guid TicketId { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Title { get; set; }
        public Guid ProjectProjectId { get; set; }

        public virtual ProjectDto ProjectProject { get; set; }
        public virtual IEnumerable<UserHasTicketDto> UserHasTicket { get; set; }
    }
}
