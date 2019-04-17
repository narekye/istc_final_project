using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ISTC.CRM.DAL.Models;
using ISTC.CRM.DAL;

namespace ISTC.CRM.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {                      
            app.Run(async (context) =>
            {                
                User user2 = new User()
                {
                    FirstName = "Nikol",
                    LastName = "Pashinyan",
                    CompanyName = "Karavarutyun",
                    Country = "Armenia",
                    Position = "Havaixosacox",
                    Email = "nikol@gmil.com",
                };
                try
                {
                    CRUD.Create(user2);
                    await context.Response.WriteAsync(CRUD.Read(1).FirstName);
                }
                catch (Exception e)
                {
                    await context.Response.WriteAsync(e.InnerException.Message);       
                }
                
            });
        }
        
    }
}
