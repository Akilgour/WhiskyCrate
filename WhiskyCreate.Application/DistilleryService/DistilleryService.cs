using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiskyCrate.Application.Contracts.Distilleries;
using WhiskyCrate.Application.Contracts.DistilleryService;
using WhiskyCrate.Data.Contracts.Repositories.Distilleries;

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

        public async Task<IEnumerable<DistilleryGetListDto>> GetDistilleries()
        {
            return mapper.Map<IEnumerable<DistilleryGetListDto>>(await distilleryRepository.GetDistilleries());
        }
    }
}