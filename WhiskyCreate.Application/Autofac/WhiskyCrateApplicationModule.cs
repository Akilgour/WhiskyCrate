using Autofac;
using System.Linq;

namespace WhiskyCrate.Application.Autofac
{
    public class WhiskyCrateApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //"ThisAssembly" means "any types in the same assembly as the module"
            builder.RegisterAssemblyTypes(ThisAssembly)
                 .Where(t => t.Name.EndsWith("Service"))
                 .AsImplementedInterfaces();
        }
    }
}