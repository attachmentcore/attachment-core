using AttachmentCore.Common.Decorators;
using AttachmentCore.Common.Models.Shared;
using AttachmentCore.SessionProvider.Cookie;
using AttachmentCore.Store.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AttachmentCore.Configuration
{
    public static class AttachmentServiceCollectionExtensions
    {
        public static IServiceCollection AddAttachment(this IServiceCollection services, Action<AttachmentServiceConfigurationOptions> options)
        {
            if (options == null)
                throw new ArgumentNullException();
            var o = new AttachmentServiceConfigurationOptions(services);
            options.Invoke(o);

            //services.Decorate<IAttachmentBusiness,AuthorizationAttachmnetBusinessDecorator>();
            services.AddScoped<AuthorizationAttachmnetBusinessDecorator>();
            return services;
        }
        public static IServiceCollection AddAttachment(this IServiceCollection services, string connectionString)
        {
            services
                .AddAttachment((o) =>
                {
                    o.UseSqlServerAttachmenBusiness(connectionString);
                    o.UseCookieSessionProvider();
                    o.UseNoAuthorizationAttachmenBusiness();
                });
            return services;
        }
        /// <summary>
        /// configure attachment by using default connection string
        /// "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=attachmentDB;Integrated Security=True;Pooling=False"
        /// </summary>
        public static IServiceCollection AddAttachment(this IServiceCollection services)
        {
            return services.AddAttachment("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=attachmentDB;Integrated Security=True;Pooling=False");
        }
    }
}
