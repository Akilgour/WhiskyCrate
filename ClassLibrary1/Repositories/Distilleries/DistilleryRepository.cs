using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiskyCrate.Data.Context;
using WhiskyCrate.Data.Contracts.Repositories.Distilleries;
using WhiskyCrate.Domain.Distilleries;

namespace WhiskyCrate.Data.Repositories.Distilleries
{
    public class DistilleryRepository : DataManager<Distillery, WhiskyCrateContext>, IDistilleryRepository
    {
        public DistilleryRepository(WhiskyCrateContext context)
          : base(context)
        {
        }

        public async Task<Distillery> AddDistillery(Distillery distillery)
        {
            context.Distilleries.Add(distillery);
            await context.SaveChangesAsync();
            return distillery;
        }

        public async Task<IEnumerable<Distillery>> GetDistilleries()
        {
            return await context.Distilleries.ToListAsync();
        }

        public async Task<Distillery> GetDistillery(int id)
        {
                return await context.Distilleries
                      .Include(distillery => distillery.WhiskyExpressions)
                      .FirstOrDefaultAsync(distillery => distillery.Id == id);
        }
    }
}