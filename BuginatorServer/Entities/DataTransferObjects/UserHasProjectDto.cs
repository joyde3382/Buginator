using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class UserHasProjectDto
    {
        public Guid UserHasProjectId { get; set; }
        public Guid UserUserId { get; set; }
        public Guid ProjectProjectId { get; set; }

        public virtual ProjectDto ProjectProject { get; set; }
        public virtual UserDto UserUser { get; set; }
    }
}
