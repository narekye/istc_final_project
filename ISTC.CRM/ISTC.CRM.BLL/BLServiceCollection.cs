using ISTC.CRM.BLL.Interfaces;
using ISTC.CRM.BLL.Services;
using ISTC.CRM.DAL.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ISTC.CRM.BLL
{
    public class BLServiceCollection
    {
        public void Configure(IServiceCollection services)
        {
            services.AddSingleton<CRMContext>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IEmailListService, EmailListService>();
        }
    }
}
