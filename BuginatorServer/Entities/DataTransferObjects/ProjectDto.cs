using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ProjectDto
    {
        public Guid ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreation { get; set; }

        public virtual IEnumerable<TicketDto> Ticket { get; set; }
        public virtual IEnumerable<UserHasProjectDto> UserHasProject { get; set; }
    }
}
