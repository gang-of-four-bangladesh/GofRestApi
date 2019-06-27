using System;
using Autofac;

namespace Gof.Api.Data
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
                throw new NullReferenceException();
            builder.RegisterType<DataContextFactory>();
        }
    }
}