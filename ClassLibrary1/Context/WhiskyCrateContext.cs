using Microsoft.EntityFrameworkCore;
using WhiskyCrate.Domain.Distillery;

namespace WhiskyCrate.Data.Context
{
    public class WhiskyCrateContext : DbContext
    {

        public DbSet<Distillery> Distilleries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = WhiskyCrate");
        }
    }
}