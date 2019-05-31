using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISTC.CRM.DAL.Models
{
    [Table("Email_Lists")]
    public partial class EmailLists
    {
        public EmailLists()
        {
            ConnectionTable = new HashSet<ConnectionTable>();
        }

        public int Id { get; set; }
        [Required]
        [Column("Email_List_Name")]
        [StringLength(50)]
        public string EmailListName { get; set; }

        [InverseProperty("EmailList")]
        public virtual ICollection<ConnectionTable> ConnectionTable { get; set; }
    }
}
