using System;
using System.Collections.Generic;

namespace ISTC.CRM.DAL.Models
{
    public partial class ConnectTable
    {
        public int IdUser { get; set; }
        public int IdMailingList { get; set; }

        public virtual MailingList IdMailingListNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
