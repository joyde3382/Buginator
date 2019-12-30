using Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User_has_project> User_has_projects { get; set; }
        public DbSet<User_has_ticket> User_Has_Tickets { get; set; }
    }
}
