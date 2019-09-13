using AttachmentCore.Common.Contracts;
using AttachmentCore.Common.Decorators;
using AttachmentCore.Common.Models.Configuration;
using AttachmentCore.Configuration;
using AttachmentCore.SessionProvider.Cookie;
using AttachmentCore.Store.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AttachmentCore.Configuration
{
    public static class AttachmentServiceCollectionExtensions
    {
        /// <summary>
        /// configure attachment by getting 'AttachmentServiceConfigurationOptions' object
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static AttachmentServiceConfigurationOptions AddAttachment(this IServiceCollection services, Action<AttachmentServiceConfigurationOptions> options)
        {
            if (options == null)
                throw new ArgumentNullException();
            var o = new AttachmentServiceConfigurationOptions(services);
            options.Invoke(o);
            return new AttachmentServiceConfigurationOptions(services);
        }
        /// <summary>
        /// configure attachment by getting connection string 
        /// </summary>
        public static AttachmentServiceConfigurationOptions AddAttachment(this IServiceCollection services, string connectionString)
        {
            return services
                    .AddAttachment((o) =>
                    {
                        o.UseSqlServerAttachmenBusiness(connectionString);
                        o.UseCookieSessionProvider();
                    });
        }
        /// <summary>
        /// configure attachment by using default connection string as following
        /// "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=attachmentDB;Integrated Security=True;Pooling=False"
        /// </summary>
        public static AttachmentServiceConfigurationOptions AddAttachment(this IServiceCollection services)
        {
            return services.AddAttachment("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=attachmentDB;Integrated Security=True;Pooling=False");
        }
    }
}
