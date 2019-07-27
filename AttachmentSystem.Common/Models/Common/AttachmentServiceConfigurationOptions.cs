using AttachmentSystem.Common.Contracts;
using AttachmentSystem.Common.Decorators;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttachmentSystem.Models.Common
{
    public class AttachmentServiceConfigurationOptions
    {
        public List<BusinessDecorator<IAttachmentBusiness>> BusinessDecorators { get; set; }
        public IServiceCollection services;
        public AttachmentServiceConfigurationOptions(IServiceCollection services)
        {
            this.services = services;
        }
    }
}
