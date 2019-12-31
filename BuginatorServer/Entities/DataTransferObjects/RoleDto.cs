using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class RoleDto
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual IEnumerable<UserDto> User { get; set; }
    }
}
