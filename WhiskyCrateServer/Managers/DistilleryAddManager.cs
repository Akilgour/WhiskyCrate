using AutoMapper;
using System.Threading.Tasks;
using WhiskyCrate.Application.Contracts.DistilleryService;
using WhiskyCrate.Domain.Distilleries;

namespace WhiskyCrate.API.Managers
{
    public interface IDistilleryAddManager
    {
        Task AddDistillery(DistilleryAddRequest distillery);
    }

    public class DistilleryAddManager : IDistilleryAddManager
    {
        private readonly IDistilleryService distilleryService;
        private readonly IMapper mapper;

        public DistilleryAddManager(IDistilleryService distilleryService, IMapper mapper)
        {
            this.distilleryService = distilleryService;
            this.mapper = mapper;
        }

        public async Task AddDistillery(DistilleryAddRequest distillery)
        {
            await distilleryService.AddDistillery(mapper.Map<Distillery>(distillery));
        }
    }

    public class DistilleryAddProfile : Profile
    {
        public DistilleryAddProfile()
        {
            CreateMap<DistilleryAddRequest, Distillery>();
        }
    }

    public class DistilleryAddRequest
    {
        public string Name { get; set; }
        public bool CurrentlyOperating { get; set; }
        public string Region { get; set; }
    }
}