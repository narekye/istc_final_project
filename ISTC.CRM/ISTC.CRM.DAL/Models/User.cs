using System;
using System.Collections.Generic;

namespace ISTC.CRM.DAL.Models
{
    public partial class User
    {
        public User()
        {
            ConnectTable = new HashSet<ConnectTable>();
        }

        public int IdUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryName { get; set; }
        public string Position { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }

        public virtual ICollection<ConnectTable> ConnectTable { get; set; }
    }
}
