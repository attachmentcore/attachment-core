using AttachmentCore.Common.Contracts;
using AttachmentCore.Common.Models.Configuration;
using AttachmentCore.Common.Models.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AttachmentCore.SessionProvider.Cookie
{
    public static class CookieAttachmentTokenProviderExtensions
    {
        public static void UseCookieSessionProvider(this AttachmentServiceConfigurationOptions _this)
        {
            _this.services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            _this.services.AddSingleton<IAttachmentSessionProvider, CookieAttachmentTokenProvider>();
        }
    }
}
