using ISTC.CRM.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISTC.CRM.BLL.Interfaces
{
    public interface IEmailListService
    {
        IEnumerable<EmailListsBL> GetAll();
    }
}
