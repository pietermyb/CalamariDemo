using Autofac;
using System.Linq;
using System.Reflection;

namespace Calamari.ClientPortal.Configuration
{
    /// <summary>
    /// Di Wiring for Service Layer
    /// </summary>
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("Calamari.Service"))

                      .Where(t => t.Name.EndsWith("Service"))
                      .AsImplementedInterfaces()
                      .InstancePerLifetimeScope();
        }
    }
}