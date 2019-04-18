using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ISTC.CRM.DAL.Models
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<ConnectionTable> ConnectionTable { get; set; }
        public virtual DbSet<EmailLists> MailLists { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ISTC.CRM.DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<ConnectionTable>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.MailListId });

                entity.ToTable("Connection_Table");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.MailListId).HasColumnName("Email_List_ID");

                entity.HasOne(d => d.MailList)
                    .WithMany(p => p.ConnectionTable)
                    .HasForeignKey(d => d.MailListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Email_List_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ConnectionTable)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_ID");
            });

            modelBuilder.Entity<EmailLists>(entity =>
            {
                entity.ToTable("Email_Lists");

                entity.HasIndex(e => e.MailListName)
                    .HasName("AK_Table_Column")
                    .IsUnique();

                entity.Property(e => e.MailListName)
                    .IsRequired()
                    .HasColumnName("Email_List_Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("AK_User_Column")
                    .IsUnique();

                entity.Property(e => e.CompanyName)
                    .HasColumnName("Company_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Position).HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
