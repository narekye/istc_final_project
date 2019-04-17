using System;
using System.Collections.Generic;

namespace ISTC.CRM.DAL.Models
{
    public partial class ConnectionTable
    {
        public int UserId { get; set; }
        public int MailListId { get; set; }

        public virtual MailList MailList { get; set; }
        public virtual User User { get; set; }
    }
}
