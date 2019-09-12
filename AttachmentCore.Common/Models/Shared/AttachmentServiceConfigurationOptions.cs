using Microsoft.Extensions.DependencyInjection;

namespace AttachmentCore.Common.Models.Shared
{
    public class AttachmentServiceConfigurationOptions
    {
        public IServiceCollection services;
        public AttachmentServiceConfigurationOptions(IServiceCollection services)
        {
            this.services = services;
        }
    }
}
