using AttachmentCore.Common.Contracts;
using AttachmentCore.Common.Decorators;
using AttachmentCore.Common.Extensions;
using AttachmentCore.Common.Models.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AttachmentCore.Store.SqlServer
{
    public static class AttachmentServiceConfigurationOptionsExtensions
    {
        public static void UseAuthorizationHandler<T>(this AttachmentServiceConfigurationOptions _this) where T : class, IAttachmentAuthorization
        {
            _this.services.AddScoped<IAttachmentAuthorization, T>();
            _this.services.Decorate<IAttachmentBusiness, AuthorizationAttachmnetBusinessDecorator>();
        }
    }
}
