using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SiamCoreRepository;
using AutoMapper.Configuration;
using SiamCoreRepository.Definitions;
using SiamCoreSite.Models;
using AutoMapper;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace SiamCoreSite
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            var dbSection = Configuration.GetSection("Database:ConnectionString");
            BaseDAL.SetConnectionString(dbSection.Value);

            // stuff from WCF version to check
            MapperConfigurationExpression mapperConfiguration = new MapperConfigurationExpression();
            mapperConfiguration.CreateMap<UserDTO, UserModel>();
            Mapper.Initialize(mapperConfiguration);
         }

        public IContainer ApplicationContainer { get; private set; }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            // Initiate AutoFac
            var autofacBuilder = new ContainerBuilder();

            autofacBuilder.RegisterType<SiamCoreRepository.BaseDAL>().As<SiamCoreRepository.IBaseDAL>().InstancePerDependency();
            autofacBuilder.RegisterType<SiamCoreServices.UsersService>().As<SiamCoreServices.IUsersService>().InstancePerDependency();
            autofacBuilder.Populate(services);


            this.ApplicationContainer = autofacBuilder.Build();
            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseMvc();
            
            DefaultFilesOptions defaultFileOptions = new DefaultFilesOptions();
            app.UseDefaultFiles(defaultFileOptions);

            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = (context) =>
                {
                    // Disable caching of all static files.
                    context.Context.Response.Headers["Cache-Control"] = "no-cache, no-store";
                    context.Context.Response.Headers["Pragma"] = "no-cache";
                    context.Context.Response.Headers["Expires"] = "-1";
                }
            });


        }
    }
}
