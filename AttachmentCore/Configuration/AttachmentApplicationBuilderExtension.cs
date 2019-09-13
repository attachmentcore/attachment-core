using AttachmentCore.Common.Models.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttachmentCore.Configuration
{
    public static class AttachmentApplicationBuilderExtension
    {
        /// <summary>
        /// configure attachment apis route so that be accessible by routes which start with 'Attachment'
        /// </summary>
        public static void UseAttachment(this IApplicationBuilder app)
        {
            app.MapWhen(ctx =>
                ctx.Request.Path.Value.StartsWith("Attachment"), AttachmentMvcApp);
        }
        /// <summary>
        /// configure routes of attachment apis  by accepting a filter expression
        /// </summary>
        /// <param name="options"></param>
        public static void UseAttachment(this IApplicationBuilder app, AttachmentAppBuilderOptions options)
        {
            if (options == null)
            {
                app.UseAttachment();
                return;
            }
            app.MapWhen(options.UseWhen, AttachmentMvcApp);
        }
        /// <summary>
        /// configuration of attachment request branch
        /// </summary>
        /// <param name="app"></param>
        private static void AttachmentMvcApp(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Attachment}/{action=Index}/{id?}");
            });
        }
    }
}
