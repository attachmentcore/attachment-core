using AttachmentSystem.Common.Contracts;
using AttachmentSystem.Common.Decorators;
using AttachmentSystem.Models.Common;
using AttachmentSystem.SessionProvider.Cookie;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace AttachmentSystem.AttachmentService
{
    public static class AttachmentServiceCollectionExtensions
    {
        public static IServiceCollection AddAttachment(this IServiceCollection services, Action<AttachmentServiceConfigurationOptions> options)
        {
            if (options == null)
                throw new ArgumentNullException();
            var o = new AttachmentServiceConfigurationOptions(services);
            options.Invoke(o);

            //services.Decorate<IAttachmentBusiness,AuthorizationBusinessDecorator>();
            return services;
        }
        public static IServiceCollection AddAttachment(this IServiceCollection services, string connectionString)
        {
            services
                .AddAttachment((o) =>
                {
                    o.UseSqlServerAttachmenBusiness(connectionString);
                    o.UseCookieSessionProvider();

                });
            return services;
        }
        public static IServiceCollection AddAttachment(this IServiceCollection services)
        {
            return services.AddAttachment("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=attachment3;Integrated Security=True;Pooling=False");
        }
    }
}
