using Autofac;
using System;

namespace Gof.Api.Feature
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
                throw new NullReferenceException();
            builder.RegisterType<UserFilterHandler>();
        }
    }
}