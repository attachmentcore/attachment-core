using AttachmentSystem.Common.Contracts;
using AttachmentSystem.Models.Common;
using Microsoft.Extensions.DependencyInjection;

namespace AttachmentSystem.Common.Decorators
{
    public static class NoAttachmnetAuthorizationBusinessExtensions
    {
        public static void UseNoAuthorizationAttachmenBusiness(this AttachmentServiceConfigurationOptions _this)
        {
            _this.services.AddScoped<IAttachmentAuthorization,NoAttachmnetAuthorizationBusiness>();
        }
    }
}
