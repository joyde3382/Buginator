using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        // use [Column("UserId")] for custom mapping
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DateOfCreation { get; set; }

        public string Email { get; set; }
        public string Note { get; set; }
        [ForeignKey("Role")]
        public Guid RoleRoleId { get; set; }

        public virtual Role RoleRole { get; set; } = new Role("tmpRole");
        public virtual ICollection<UserHasProject> UserHasProject { get; set; }
        public virtual ICollection<UserHasTicket> UserHasTicket { get; set; }
    }
}

//scaffolding command to autogenerate entities
//dotnet ef dbcontext scaffold "server=localhost;user id=root;password=Jonaspotter321;persistsecurityinfo=True;database=buginatordb" "Pomelo.EntityFrameWorkCore.MySql" -o.\Models2 -f