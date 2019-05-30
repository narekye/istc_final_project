using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISTC.CRM.DAL.Models
{
    [Table("Connection_Table")]
    public partial class ConnectionTable
    {
        [Column("User_ID")]
        public int UserId { get; set; }
        [Column("Email_List_ID")]
        public int EmailListId { get; set; }

        [ForeignKey("EmailListId")]
        [InverseProperty("ConnectionTable")]
        public virtual EmailLists EmailList { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("ConnectionTable")]
        public virtual User User { get; set; }
    }
}
