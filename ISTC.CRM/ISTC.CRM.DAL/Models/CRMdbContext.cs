using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ISTC.CRM.DAL.Models
{
    public partial class CRMdbContext : DbContext
    {
        public CRMdbContext()
        {
        }

        public CRMdbContext(DbContextOptions<CRMdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConnectTable> ConnectTable { get; set; }
        public virtual DbSet<MailingList> MailingList { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-DTQ5Q8H;Initial Catalog=CRMdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<ConnectTable>(entity =>
            {
                entity.HasKey(e => new { e.IdUser, e.IdMailingList });

                entity.Property(e => e.IdUser).HasColumnName("ID_User");

                entity.Property(e => e.IdMailingList).HasColumnName("ID_MailingList");

                entity.HasOne(d => d.IdMailingListNavigation)
                    .WithMany(p => p.ConnectTable)
                    .HasForeignKey(d => d.IdMailingList)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConnectTable_MailingList");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.ConnectTable)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConnectTable_User");
            });

            modelBuilder.Entity<MailingList>(entity =>
            {
                entity.HasKey(e => e.IdMailingList);

                entity.Property(e => e.IdMailingList).HasColumnName("ID_MailingList");

                entity.Property(e => e.MailingListName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.Property(e => e.IdUser).HasColumnName("ID_User");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
