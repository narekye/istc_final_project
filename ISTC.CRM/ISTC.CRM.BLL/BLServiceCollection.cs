using ISTC.CRM.BLL.Interfaces;
using ISTC.CRM.BLL.Services;
using ISTC.CRM.DAL.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ISTC.CRM.BLL
{
    // Collection of BLL Services
    public static class BLServiceCollection
    {
        // Extension method
        public static void ConfigureCRMServices(this IServiceCollection services)
        {
            services.AddSingleton<CRMContext>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IEmailListService, EmailListService>();
        }
    }
}
