using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ISTC.CRM.DAL.Models
{
    public partial class CRMContext : DbContext
    {
        public CRMContext()
        {
        }

        public CRMContext(DbContextOptions<CRMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConnectionTable> ConnectionTable { get; set; }
        public virtual DbSet<EmailLists> EmailLists { get; set; }
        public virtual DbSet<EmailTemplate> EmailTemplate { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=visual.istclabz.com;Integrated Security=false;Initial Catalog=istc_crm;User id=istc_student;Password=Qwe@1234;Encrypt=True;persist security info=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<ConnectionTable>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.EmailListId });

                entity.HasOne(d => d.EmailList)
                    .WithMany(p => p.ConnectionTable)
                    .HasForeignKey(d => d.EmailListId)
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
                entity.HasIndex(e => e.EmailListName)
                    .HasName("AK_Table_Column")
                    .IsUnique();
            });

            modelBuilder.Entity<EmailTemplate>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("AK_User_Column")
                    .IsUnique();
            });
        }
    }
}
