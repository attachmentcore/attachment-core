using AttachmentSystem.Common.Contracts;
using AttachmentSystem.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AttachmentSystem.SessionProvider.Cookie
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
