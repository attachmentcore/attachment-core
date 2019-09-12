using AttachmentCore.Common.Contracts;
using AttachmentCore.Common.Models.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace AttachmentCore.Common.Decorators
{
    public static class NoAttachmnetAuthorizationBusinessExtensions
    {
        public static void UseNoAuthorizationAttachmenBusiness(this AttachmentServiceConfigurationOptions _this)
        {
            _this.services.AddScoped<IAttachmentAuthorization, NoAttachmnetAuthorizationBusiness>();
        }
    }
}
