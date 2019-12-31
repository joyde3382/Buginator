using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public Guid RoleRoleId { get; set; }

        public virtual RoleDto RoleRole { get; set; }
        public virtual IEnumerable<UserHasProjectDto> UserHasProject { get; set; }
        public virtual IEnumerable<UserHasTicketDto> UserHasTicket { get; set; }
    }
}

