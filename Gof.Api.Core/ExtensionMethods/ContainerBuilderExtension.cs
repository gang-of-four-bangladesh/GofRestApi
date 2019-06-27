using System;
using System.Reflection;
using Autofac;
using Autofac.Builder;
using Autofac.Features.Scanning;

namespace Gof.Api.Core.ExtensionMethods
{
    public static class ContainerBuilderExtension
    {
        public static IRegistrationBuilder<TService, ConcreteReflectionActivatorData, SingleRegistrationStyle> Register<TService>(this ContainerBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            return builder.RegisterType<TService>()
                          .AsSelf()
                          .AsImplementedInterfaces();
        }

        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> RegisterClosingTypes(this ContainerBuilder instance, Type type, params Assembly[] assemblies)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            return instance.RegisterAssemblyTypes(assemblies)
                .AsSelf()
                .AsClosedTypesOf(type)
                .AsImplementedInterfaces();
        }
    }
}