using Autofac;
using System.Linq;

namespace WhiskyCrate.Data.Autofac
{
    public class WhiskyCrateDataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //There is no need of the context param, as that is worked out by the MS Dependancy injector
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
        }
    }
}