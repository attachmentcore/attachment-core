using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttachmentSystem.Models.Common;
using AttachmentSystem.Store.SqlServer.Businesses;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AttachmentSystem.AttachmentService;
using AttachmentSystem.ApplicationBuilder;
using AttachmentSystem.SessionProvider.Cookie;

namespace WebApplication10
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            
            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            }));
            //services
            //    .AddAttachment((o) =>
            //    {
            //        o.UseSqlServerAttachmenBusiness("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=attachment2;Integrated Security=True;Pooling=False");
            //        o.UseCookieSessionProvider();

            //    });
            services.AddAttachment();
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseCors("AllowAll");
            
            app.UseAttachment(new AttachmentAppBuilderOptions()
            {
                UseWhen = ctx => ctx.Request.Path.Value.StartsWith("Attachment")
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
