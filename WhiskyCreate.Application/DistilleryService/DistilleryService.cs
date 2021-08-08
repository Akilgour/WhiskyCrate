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

        public async Task AddDistillery(Distillery distillery)
        {
            await distilleryRepository.AddDistillery(distillery);
        }

        public async Task<bool> DeleteDistillery(int id)
        {
            return await distilleryRepository.DeleteDistillery(id);
        }

        public async Task<bool> DistilleryExists(int id)
        {
            return await distilleryRepository.DistilleryExists(id);
        }

        public async Task<IEnumerable<Distillery>> GetDistilleries()
        {
            return await distilleryRepository.GetDistilleries();
        }

        public async Task<Distillery> GetDistillery(int id)
        {
            return await distilleryRepository.GetDistillery(id);
        }

        public async Task UpdateDistillery(Distillery distillery)
        {
            await distilleryRepository.UpdateDistillery(distillery);
        }
    }
}