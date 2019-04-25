using System;
using System.Collections.Generic;

namespace ISTC.CRM.BLL.Models
{
    public partial class ConnectionTableBL
    {
        public int UserId { get; set; }
        public int MailListId { get; set; }

        public virtual EmailListsBL MailList { get; set; }
        public virtual UserBL User { get; set; }
    }
}
