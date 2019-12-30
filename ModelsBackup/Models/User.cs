using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("user")]
    public partial class User
    {
        public User()
        {
            UserHasProject = new HashSet<UserHasProject>();
            UserHasTicket = new HashSet<UserHasTicket>();
        }

        public Guid UserId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public Guid RoleRoleId { get; set; }

        public virtual Role RoleRole { get; set; }
        public virtual ICollection<UserHasProject> UserHasProject { get; set; }
        public virtual ICollection<UserHasTicket> UserHasTicket { get; set; }
    }
}
