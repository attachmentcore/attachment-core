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
        public List<AttachmentBusinessDecorator> BusinessDecorators { get; set; }
        public IServiceCollection services;
        public AttachmentServiceConfigurationOptions(IServiceCollection services)
        {
            this.services = services;
        }
    }
}
