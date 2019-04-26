using System;
using System.Collections.Generic;

namespace ISTC.CRM.BLL.Models
{
    public partial class EmailListsBL
    {
        public EmailListsBL()
        {
            //ConnectionTable = new HashSet<ConnectionTableBL>();
        }

        public int Id { get; set; }
        public string MailListName { get; set; }

        //public virtual ICollection<ConnectionTableBL> ConnectionTable { get; set; }
    }
}
