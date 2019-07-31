using AttachmentSystem.Models.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttachmentSystem.ApplicationBuilder
{
    public static class AttachmentApplicationBuilderExtension
    {
        public static void UseAttachment(this IApplicationBuilder app)
        {
            app.MapWhen(ctx =>
                ctx.Request.Path.Value.StartsWith("Attachment"), AttachmentMvcApp);
        }
        public static void UseAttachment(this IApplicationBuilder app, AttachmentAppBuilderOptions options)
        {
            if (options == null)
            {
                app.UseAttachment();
                return;
            }
            app.MapWhen(options.UseWhen, AttachmentMvcApp);
        }
        private static void AttachmentMvcApp(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Attachment}/{action=Index1}/{id?}");
            });
        }
    }
}
