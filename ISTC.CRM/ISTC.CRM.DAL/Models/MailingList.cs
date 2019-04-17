using System;
using System.Collections.Generic;

namespace ISTC.CRM.DAL.Models
{
    public partial class MailingList
    {
        public MailingList()
        {
            ConnectTable = new HashSet<ConnectTable>();
        }

        public int IdMailingList { get; set; }
        public string MailingListName { get; set; }

        public virtual ICollection<ConnectTable> ConnectTable { get; set; }
    }
}
