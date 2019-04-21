using System;
using System.Collections.Generic;

namespace ISTC.CRM.BLL.Models
{
    public partial class UserBL
    {
        public UserBL()
        {
            ConnectionTable = new HashSet<ConnectionTableBL>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }

        public virtual ICollection<ConnectionTableBL> ConnectionTable { get; set; }
    }
}
