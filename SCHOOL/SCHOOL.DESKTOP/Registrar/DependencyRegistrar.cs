using Autofac;
using SCHOOL.DATA.Implementation;
using SCHOOL.DATA.Infrastructure;
using System.Reflection;

namespace SCHOOL.DESKTOP.Registrar
{
    public static class DependencyRegistrar
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(Assembly.Load("SCHOOL.DESKTOP"))
                .Where(t => t.Name.EndsWith("Window"))
                .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(Assembly.Load("SCHOOL.SERVICES"))
                    .Where(t => t.Name.EndsWith("Service"))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.Load("SCHOOL.FACADE"))
                    .Where(t => t.Name.EndsWith("Facade"))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
            var container = builder.Build();
            //MainWindow mainWindow = container.Resolve<MainWindow>();
        }
    }
}