using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Http;

namespace Gof.Api.Web
{
    using Gof.Api.Core.Infrastructure;
    using Gof.Api.Core.Logger;
    using Gof.Api.Data;
    using Gof.Api.Dto;
    using Gof.Api.Feature;

    public class Startup
    {
        private readonly IHostingEnvironment _environment;
        private readonly IConfiguration _configuration;
        private IContainer ApplicationContainer;

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            this._configuration = configuration;
            this._environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>((DbContextOptionsBuilder options) =>
            {
                //var connectionString = this._configuration.GetSection("ConnectionStrings")["DefaultConnection"];
                var connectionString = "Server=localhost;Database=Gof;User Id=sa;password=reallyStrongPwd123;Trusted_Connection=False;MultipleActiveResultSets=true;";
                options.UseSqlServer(connectionString);
            });
            services.AddMvc();

            LoggerConfigurationHelper.ConfigureLogger(this._configuration);
            var builder = new ContainerBuilder();
            builder.Populate(services);

            var assemblies = AssembliesProvider.Instance.Assemblies.ToArray();
            builder.RegisterAssemblyModules(assemblies);
            this.ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime)
        {
            lifetime.ApplicationStopping.Register(() =>
            {
                Log.CloseAndFlush();
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
