using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using caixa_eletronico.Application;
using caixa_eletronico.Application.Interfaces;
using caixa_eletronico.Infrastructure.Database;
using caixa_eletronico.Infrastructure.Repositories;
using caixa_eletronico.Infrastructure.Repositories.Interfaces;
using caixa_eletronico.Services;
using caixa_eletronico.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace caixa_eletronico
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            // Dependency Injection

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IBillsApplication, BillsApplication>();
            services.AddScoped<IWadOfBillsApplication, WadOfBillsApplication>();

            services.AddScoped<IBillsService, BillsService>();
            services.AddScoped<IWadOfBillsService, WadOfBillsService>();

            services.AddScoped<IBillsRepository, BillsRepository>();
            services.AddScoped<IWadOfBillsRepository, WadOfBillsRepository>();

            services.AddScoped(typeof(ATMDbContext));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=WadOfBills}/{action=Index}/{id?}");
            });
        }
    }
}
