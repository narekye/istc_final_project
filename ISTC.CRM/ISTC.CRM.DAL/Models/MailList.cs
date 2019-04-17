﻿using System;
using System.Collections.Generic;

namespace ISTC.CRM.DAL.Models
{
    public partial class MailList
    {
        public MailList()
        {
            ConnectionTable = new HashSet<ConnectionTable>();
        }

        public int Id { get; set; }
        public string MailListName { get; set; }

        public virtual ICollection<ConnectionTable> ConnectionTable { get; set; }
    }
}
