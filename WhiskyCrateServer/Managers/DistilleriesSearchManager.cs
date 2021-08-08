using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiskyCrate.Application.Contracts.DistilleryService;
using WhiskyCrate.Domain.Distilleries;

namespace WhiskyCrate.API.Managers
{
    public interface ISearchDistilleriesManager
    {
        Task<IEnumerable<DistillerySearchResult>> GetDistilleries();
    }

    public class DistilleriesSearchManager : ISearchDistilleriesManager
    {
        private readonly IDistilleryService distilleryService;
        private readonly IMapper mapper;

        public DistilleriesSearchManager(IDistilleryService distilleryService, IMapper mapper)
        {
            this.distilleryService = distilleryService;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<DistillerySearchResult>> GetDistilleries()
        {
            return mapper.Map<IEnumerable<DistillerySearchResult>>(await distilleryService.GetDistilleries());
        }
    }

    public class DistilleriesSearchManagerProfile : Profile
    {
        public DistilleriesSearchManagerProfile()
        {
            CreateMap<Distillery, DistillerySearchResult>();
        }
    }

    public class DistillerySearchResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool CurrentlyOperating { get; set; }
        public string Region { get; set; }
    }
}