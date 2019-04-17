using System;
using System.Collections.Generic;

namespace ISTC.CRM.DAL.Models
{
    public partial class User
    {
        public User()
        {
            ConnectionTable = new HashSet<ConnectionTable>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public virtual ICollection<ConnectionTable> ConnectionTable { get; set; }
    }
}
