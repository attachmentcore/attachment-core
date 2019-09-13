using Microsoft.Extensions.DependencyInjection;

namespace AttachmentCore.Common.Models.Configuration
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
