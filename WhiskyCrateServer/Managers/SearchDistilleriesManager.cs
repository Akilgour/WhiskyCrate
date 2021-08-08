using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiskyCrate.Application.Contracts.DistilleryService;
using WhiskyCrate.Domain.Distilleries;

namespace WhiskyCrate.API.Managers
{
    public interface ISearchDistilleriesManager
    {
        Task<IEnumerable<SearchsDistilleryResult>> GetDistilleries();
    }

    public class SearchDistilleriesManager : ISearchDistilleriesManager
    {
        private readonly IDistilleryService distilleryService;
        private readonly IMapper mapper;

        public SearchDistilleriesManager(IDistilleryService distilleryService, IMapper mapper)
        {
            this.distilleryService = distilleryService;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SearchsDistilleryResult>> GetDistilleries()
        {
            return mapper.Map<IEnumerable<SearchsDistilleryResult>>(await distilleryService.GetDistilleries());
        }
    }

    public class SearchDistilleriesManagerProfile : Profile
    {
        public SearchDistilleriesManagerProfile()
        {
            CreateMap<Distillery, SearchsDistilleryResult>();
        }
    }

    public class SearchsDistilleryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool CurrentlyOperating { get; set; }
        public string Region { get; set; }
    }
}