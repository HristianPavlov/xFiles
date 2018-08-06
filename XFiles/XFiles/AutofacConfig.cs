using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using xFiles.Data;
using xFiles.Services;
namespace XFiles
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Register dependencies in controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

           
            // Register dependencies in custom views
            builder.RegisterSource(new ViewRegistrationSource());

            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            // Register our Data dependencies

            builder.RegisterType<XFilesSystemContext>().As<IXFilesSystemContext>().InstancePerDependency();
            builder.RegisterType<CreateService>().As<ICreateService>().InstancePerDependency();

         


            //builder.Register(x => Mapper.Instance);


            var container = builder.Build();

            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}