using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using ISTC.CRM.BLL;

namespace ISTC.CRM.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureCRMServices();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", o =>
                {
                    o.AllowAnyOrigin();
                    o.AllowCredentials();
                    o.AllowAnyMethod();
                    o.AllowAnyHeader();
                });
            });

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAll");
            app.UseWelcomePage("/");
            app.UseMvc();
        }
    }
}
