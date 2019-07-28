using AttachmentSystem.Common.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AttachmentSystem.Common.Decorators
{
    public static class BusinessDecoratorExtensions
    {
        public static IServiceCollection Decorate<TBusiness, TDecorator>(this IServiceCollection services) where TBusiness : IAttachmentBusiness where TDecorator : AttachmentBusinessDecorator
        {
            var serviceRegisterations = services.Where(z => z.ServiceType == typeof(TBusiness)).ToList();
            foreach (var serviceRegisteration in serviceRegisterations)
            {
                
                //var service = ActivatorUtilities.CreateInstance(serviceProvider, typeof(TDecorator));
                if (serviceRegisteration.ImplementationFactory != null)
                {
                    // Factory-based
                    services.Add(new ServiceDescriptor(
                    serviceRegisteration.ServiceType,
                    (p) =>
                    {
                        //return (TDecorator)Activator.CreateInstance(typeof(TDecorator), (TBusiness)serviceRegisteration.ImplementationFactory.Invoke(p)); 
                        var service = ActivatorUtilities.CreateInstance(p, typeof(TDecorator));

                        return service;
                    },
                    serviceRegisteration.Lifetime));
                }
                else
                {
                    // Type-based
                    services.Add(new ServiceDescriptor(
                    serviceRegisteration.ServiceType,
                    (p) =>
                    {
                        //return (TDecorator)Activator.CreateInstance(typeof(TDecorator), (TBusiness)Activator.CreateInstance(serviceRegisteration.ImplementationType));
                        var service = ActivatorUtilities.CreateInstance(p, typeof(TDecorator));

                        return service;
                    },
                    serviceRegisteration.Lifetime));
                }
                services.Remove(serviceRegisteration);
            }
            return services;
        }
    }
}
