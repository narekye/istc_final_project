using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISTC.CRM.DAL.Models
{
    public partial class EmailTemplate
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public bool IsHtml { get; set; }
        public string Data { get; set; }
    }
}
