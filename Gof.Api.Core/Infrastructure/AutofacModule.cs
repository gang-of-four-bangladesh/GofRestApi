using System;
using Autofac;
using AutofacSerilogIntegration;
using System.Linq;
using System.Collections.Generic;
using Gof.Api.Core.ExtensionMethods;
using Gof.Api.Core.Infrastructure;

namespace Gof.Api.Core.Infrastructure
{
    using ExtensionMethods;
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            var assemblies = AssembliesProvider.Instance.Assemblies.ToArray();
            builder.Register<Func<Type, object>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();
                return ctx.Resolve;
            });
            
            builder.RegisterClosingTypes(typeof(ICommandHandler<,>), assemblies)
                .PreserveExistingDefaults();

            builder.RegisterLogger(); //Autofac serilog integration
            RegisterCoreComponents(builder);
        }

        private static void RegisterCoreComponents(ContainerBuilder builder)
        {
            builder.Register<CommandBus>();
        }
    }
}