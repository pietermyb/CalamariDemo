using Autofac;
using Calamari.Repository.Context;
using Calamari.Service;
using Calamari.Service.Contracts;
using System.Data.Entity;

namespace Calamari.Configuration
{
    /// <summary>
    /// EF DI Wiring
    /// </summary>
    public class EFModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());

            builder.RegisterType(typeof(CalamariContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();
        }
    }
}