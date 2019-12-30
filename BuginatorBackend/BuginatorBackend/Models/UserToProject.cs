using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuginatorBackend.Models
{
    public class UserToProject
    {
        public Guid userToProjectId { get; set; }

        [ForeignKey(nameof(User))]
        public Guid userId { get; set; }
        public User user { get; set; }

        [ForeignKey(nameof(Project))]
        public Guid projectId { get; set; }
        public Project project { get; set; }
    }
}
