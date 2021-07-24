using System.Collections.Generic;
using System.Threading.Tasks;
using WhiskyCrate.Application.Contracts.DistilleryService;
using WhiskyCrate.Data.Contracts.Repositories.Distilleries;
using WhiskyCrate.Domain.Distilleries;

namespace WhiskyCrate.Application.DistilleryService
{
    public class DistilleryService : IDistilleryService
    {
        private readonly IDistilleryRepository distilleryRepository;

        public DistilleryService(IDistilleryRepository distilleryRepository)
        {
            this.distilleryRepository = distilleryRepository;
        }

        public async Task<IEnumerable<Distillery>> GetDistilleries()
        {
            return await distilleryRepository.GetDistilleries();
        }
    }
}