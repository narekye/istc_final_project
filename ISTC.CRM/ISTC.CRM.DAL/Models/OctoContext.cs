using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ISTC.CRM.DAL.Models
{
    public partial class OctoContext : DbContext
    {
        public OctoContext()
        {
        }

        public OctoContext(DbContextOptions<OctoContext> options)
            : base(options)
        {
        }

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
        }
    }
}
