//using Entities.Models;
//using Microsoft.EntityFrameworkCore;


//namespace Entities
//{
//    public class RepositoryContext : DbContext
//    {
//        public RepositoryContext(DbContextOptions options)
//            : base(options)
//        {
//        }

//        public DbSet<User> Users { get; set; }
//        public DbSet<Project> Projects { get; set; }
//        public DbSet<Ticket> Tickets { get; set; }
//        public DbSet<Role> Roles { get; set; }
//        public DbSet<UserHasProject> User_has_projects { get; set; }
//        public DbSet<UserHasTicket> User_has_tickets { get; set; }
//    }
//}

using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities
{
    public partial class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {

        }

        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserHasProject> UserHasProject { get; set; }
        public virtual DbSet<UserHasTicket> UserHasTicket { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;user id=root;password=Jonaspotter321;persistsecurityinfo=True;database=buginatordb", x => x.ServerVersion("8.0.18-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("project");

                entity.Property(e => e.ProjectId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DateOfCreation).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.RoleId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RoleName)
                    //.IsRequired()
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("ticket");

                entity.HasIndex(e => e.ProjectProjectId)
                    .HasName("fk_Ticket_Project1_idx");

                entity.Property(e => e.TicketId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DateOfCreation).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProjectProjectId)
                    .HasColumnName("Project_ProjectId")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.ProjectProject)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.ProjectProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Ticket_Project1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.RoleRoleId)
                    .HasName("fk_User_Role_idx");

                entity.Property(e => e.UserId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Age).HasColumnType("int(11)");

                entity.Property(e => e.DateOfCreation)
                    .IsRequired()
                    .HasDefaultValueSql("getdate()")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    //.IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Note)
                    //.IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RoleRoleId)
                    .HasColumnName("Role_RoleId")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.RoleRole)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_User_Role");
            });

            modelBuilder.Entity<UserHasProject>(entity =>
            {
                entity.HasKey(e => new { e.UserHasProjectId, e.UserUserId, e.ProjectProjectId })
                    .HasName("PRIMARY");

                entity.ToTable("user_has_project");

                entity.HasIndex(e => e.ProjectProjectId)
                    .HasName("fk_User_has_Project_Project1_idx");

                entity.HasIndex(e => e.UserUserId)
                    .HasName("fk_User_has_Project_User1_idx");

                entity.Property(e => e.UserHasProjectId)
                    .HasColumnName("User_has_projectId")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserUserId)
                    .HasColumnName("User_UserId")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProjectProjectId)
                    .HasColumnName("Project_ProjectId")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.ProjectProject)
                    .WithMany(p => p.UserHasProject)
                    .HasForeignKey(d => d.ProjectProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_User_has_Project_Project1");

                entity.HasOne(d => d.UserUser)
                    .WithMany(p => p.UserHasProject)
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_User_has_Project_User1");
            });

            modelBuilder.Entity<UserHasTicket>(entity =>
            {
                entity.HasKey(e => new { e.UserUserId, e.TicketTicketId })
                    .HasName("PRIMARY");

                entity.ToTable("user_has_ticket");

                entity.HasIndex(e => e.TicketTicketId)
                    .HasName("fk_User_has_Ticket_Ticket1_idx");

                entity.HasIndex(e => e.UserUserId)
                    .HasName("fk_User_has_Ticket_User1_idx");

                entity.Property(e => e.UserUserId)
                    .HasColumnName("User_UserId")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TicketTicketId)
                    .HasColumnName("Ticket_TicketId")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserHasTicketId)
                    .HasColumnName("User_has_TicketId")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserTicketRole)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.TicketTicket)
                    .WithMany(p => p.UserHasTicket)
                    .HasForeignKey(d => d.TicketTicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_User_has_Ticket_Ticket1");

                entity.HasOne(d => d.UserUser)
                    .WithMany(p => p.UserHasTicket)
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_User_has_Ticket_User1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

