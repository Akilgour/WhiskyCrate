using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiskyCrate.Application.Contracts.Distilleries;
using WhiskyCrate.Application.Contracts.DistilleryService;
using WhiskyCrate.Data.Contracts.Repositories.Distilleries;
using WhiskyCrate.Domain.Distilleries;

namespace WhiskyCrate.Application.DistilleryService
{
    public class DistilleryService : IDistilleryService
    {
        private readonly IDistilleryRepository distilleryRepository;
        private readonly IMapper mapper;

        public DistilleryService(IDistilleryRepository distilleryRepository, IMapper mapper)
        {
            this.distilleryRepository = distilleryRepository;
            this.mapper = mapper;
        }

        public async Task<DistilleryGetDto> AddDistillery(DistilleryPostRequest distillery)
        {
            var result = await distilleryRepository.AddDistillery(mapper.Map<Distillery>(distillery));
            return mapper.Map<DistilleryGetDto>(result);
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