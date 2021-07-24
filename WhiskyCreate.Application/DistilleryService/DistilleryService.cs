using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiskyCrate.Application.Contracts.DistilleryService;
using WhiskyCrate.Data.Context;
using WhiskyCrate.Domain.Distilleries;

namespace WhiskyCrate.Application.DistilleryService
{
    public class DistilleryService : IDistilleryService
    {
        private readonly WhiskyCrateContext _context;

        public DistilleryService(WhiskyCrateContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Distillery>> GetDistilleries()
        {
            return await _context.Distilleries.ToListAsync();
        }
    }
}