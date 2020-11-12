using Autofac;
using AutoMapper;
using SCHOOL.DATA.Implementation;
using SCHOOL.DATA.Infrastructure;
using SCHOOL.MAP;
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
            var autoMapperProfile = new MapperConfigurationInternal();

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(autoMapperProfile);
            }));

            //register your mapper
            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>().SingleInstance();
            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var main = scope.Resolve<MainWindow>();
                main.ShowDialog();
            }
        }
    }
}