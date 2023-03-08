using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mission09_sk389.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_sk389
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        
        //IConfiguration goes and gets info from appsettings.json
        public IConfiguration Configuration { get; set; }

        //Constructor to get the above set up
        public Startup (IConfiguration temp)
        {
            Configuration = temp;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //Service that tells the program to use MVC setup
            services.AddControllersWithViews();

            services.AddDbContext<BookstoreContext>(options =>
                {
                    options.UseSqlite(Configuration["ConnectionStrings:BookstoreDBConnection"]);
                });

            services.AddScoped<IBookstoreRepository, EFBookstoreRepository>();

            services.AddRazorPages();

            //Enable saving a session
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Tells asp.net to use the files in the wwwroot folder
            app.UseStaticFiles();
            //Sessions
            app.UseSession();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //When category and page are specified
                endpoints.MapControllerRoute(
                name: "categorypage",
                pattern: "{category}/page{pageNum}",
                defaults: new { Controller = "Home", action = "Index" });

                //Endpoint to determine what comes in and create what comes out when page is specified
                endpoints.MapControllerRoute(
                    name: "Paging",
                    pattern: "page{pageNum}",
                    defaults: new { Controller = "Home", action = "Index", pageNum = 1 });

                //When category (only) is specified (send them to the first page of each category
                endpoints.MapControllerRoute(
                name: "category",
                pattern: "{category}",
                defaults: new { Controller = "Home", action = "Index", pageNum = 1 });
               
                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();
            });
        }
    }
}
