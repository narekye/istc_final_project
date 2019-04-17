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
        public virtual DbSet<MailList> MailList { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OOO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<ConnectionTable>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.MailListId })
                    .HasName("UNIQUE_ID_MailListID");

                entity.ToTable("CONNECTION_TABLE");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.Property(e => e.MailListId).HasColumnName("MAIL_LIST_ID");

                entity.HasOne(d => d.MailList)
                    .WithMany(p => p.ConnectionTable)
                    .HasForeignKey(d => d.MailListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MAIL_LIST_ID_FK");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ConnectionTable)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USER_ID_FK");
            });

            modelBuilder.Entity<MailList>(entity =>
            {
                entity.ToTable("MAIL_LIST");

                entity.HasIndex(e => e.MailListName)
                    .HasName("UQ__MAIL_LIS__D40F7D008BF2E821")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MailListName)
                    .HasColumnName("MAIL_LIST_NAME")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__USER__161CF724A6401A6D")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .HasColumnName("SURNAME")
                    .HasMaxLength(50);
            });
        }
    }
}
