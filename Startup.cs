using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyBlogMvcProject.Data;
using MyBlogMvcProject.Models;
using MyBlogMvcProject.Services;
using MyBlogMvcProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogMvcProject
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
            services.AddDbContext<ApplicationDbContext>(options => // Responsible for registering your services with the opportunity to talk to the database
               options.UseNpgsql(// Responsible for talking specifically to Microsoft sickle server
                   Configuration.GetConnectionString("DefaultConnection"))); //This line get the connection string that will be use to talk to SQL server.

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<BlogUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();

            services.AddRazorPages();

            //Register my custom DataService class
            services.AddScoped<DataService>();

            //Register a preconfigured instance of the MailSettings class
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddScoped<IBlogEmailSender, EmailService>();

            //Register my custom DataService class as a Service
            services.AddScoped<DataService>();

            //Register our Image Service
            services.AddScoped<IImageService, BasicImageService>();

            //Register the Slug Service
            services.AddScoped<ISlugService, BasicSlugService>();

            //Register a preconfigured instance of the mail class
            //services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            //services.AddScoped<IBlogEmailSender, EmailService>();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();

               
                


            });
        }
    }
}
