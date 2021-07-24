using Autofac;
using System.Linq;
using WhiskyCrate.Data.Autofac;

namespace WhiskyCrate.Application.Autofac
{
    public class WhiskyCrateApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new WhiskyCrateDataModule());

            //"ThisAssembly" means "any types in the same assembly as the module"
            builder.RegisterAssemblyTypes(ThisAssembly)
                 .Where(t => t.Name.EndsWith("Service"))
                 .AsImplementedInterfaces();
        }
    }
}