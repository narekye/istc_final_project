using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISTC.CRM.DAL.Models
{
    public partial class User
    {
        public User()
        {
            ConnectionTable = new HashSet<ConnectionTable>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Surname { get; set; }
        [Column("Company_Name")]
        [StringLength(50)]
        public string CompanyName { get; set; }
        [StringLength(50)]
        public string Position { get; set; }
        [StringLength(50)]
        public string Country { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<ConnectionTable> ConnectionTable { get; set; }
    }
}
