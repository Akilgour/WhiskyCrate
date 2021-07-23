using Microsoft.EntityFrameworkCore;
using WhiskyCrate.Domain.Distillery;

namespace WhiskyCrate.Data.Context
{
    public class WhiskyCrateContext : DbContext
    {
        //This is called from
        //WhiskyCrate.API => StartUp.cs => ConfigureServices(IServiceCollection services)
        public WhiskyCrateContext(DbContextOptions<WhiskyCrateContext> options)
            :base(options)
        {

        }

        public DbSet<Distillery> Distilleries { get; set; }
    }
}