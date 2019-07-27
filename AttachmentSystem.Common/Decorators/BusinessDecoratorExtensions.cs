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
        public static IServiceCollection Decorate<TBusiness, TDecorator>(this IServiceCollection services) where TBusiness : class where TDecorator : BusinessDecorator<TBusiness>
        {
            var serviceRegisterations = services.Where(z => z.ServiceType == typeof(TBusiness)).ToList();
            foreach (var serviceRegisteration in serviceRegisterations)
            {
                services.Remove(serviceRegisteration);
                if (serviceRegisteration.ImplementationFactory != null)
                {
                    // Factory-based
                    services.Add(new ServiceDescriptor(
                    serviceRegisteration.ServiceType,
                    (p) =>
                    {
                        return BusinessDecorator<TBusiness>.GetDecorated<TDecorator>(serviceRegisteration.ImplementationFactory.Invoke(p) as TBusiness);
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
                        return BusinessDecorator<TBusiness>.GetDecorated<TDecorator>((TBusiness)Activator.CreateInstance(serviceRegisteration.ImplementationType));
                    },
                    serviceRegisteration.Lifetime));
                }
            }
            return services;
        }
    }
}
