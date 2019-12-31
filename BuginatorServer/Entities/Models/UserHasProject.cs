using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("userHasProject")]
    public partial class UserHasProject
    {
        public Guid UserHasProjectId { get; set; }
        public Guid UserUserId { get; set; }
        public Guid ProjectProjectId { get; set; }

        public virtual Project ProjectProject { get; set; }
        public virtual User UserUser { get; set; }
    }
}
