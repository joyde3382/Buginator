using System;
using System.Collections.Generic;
using System.Text;

using BuginatorBackend.Models;
using Microsoft.EntityFrameworkCore;


namespace BuginatorBackend
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
    }
}
