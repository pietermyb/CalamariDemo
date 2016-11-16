using Autofac;
using System.Linq;
using System.Reflection;

namespace Calamari.ClientPortal.Configuration
{
    /// <summary>
    /// Di Wiring for Repository
    /// </summary>
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("Calamari.Repository"))
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces()
                  .InstancePerLifetimeScope();
        }
    }
}