using Microsoft.EntityFrameworkCore;
using WhiskyCrate.Domain.Distilleries;
using WhiskyCrate.Domain.WhiskyExpressions;

namespace WhiskyCrate.Data.Context
{
    public class WhiskyCrateContext : DbContext
    {
        public WhiskyCrateContext()
        {
        }

        //This is called from
        //WhiskyCrate.API => StartUp.cs => ConfigureServices(IServiceCollection services)
        public WhiskyCrateContext(DbContextOptions<WhiskyCrateContext> options)
            :base(options)
        {

        }

        public DbSet<Distillery> Distilleries { get; set; }
        public DbSet<WhiskyExpression> WhiskyExpressions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = WhiskyCrate");
            }
        }
    }
}