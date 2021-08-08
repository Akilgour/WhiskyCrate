using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiskyCrate.Application.Contracts.DistilleryService;
using WhiskyCrate.Application.Helpers;
using WhiskyCrate.Domain.Distilleries;
using WhiskyCrate.Domain.WhiskyExpressions;

namespace WhiskyCrate.API.Managers
{
    public interface IGetDistilleryManager
    {
        Task<DistilleryGetResult> GetDistillery(int id);
    }

    public class DistilleryGetManager : IGetDistilleryManager
    {
        private readonly IDistilleryService distilleryService;
        private readonly IMapper mapper;

        public DistilleryGetManager(IDistilleryService distilleryService, IMapper mapper)
        {
            this.distilleryService = distilleryService;
            this.mapper = mapper;
        }

        public async Task<DistilleryGetResult> GetDistillery(int id)
        {
            return mapper.Map<DistilleryGetResult>(await distilleryService.GetDistillery(id));
        }
    }

    public class GetDistilleryProfile : Profile
    {
        public GetDistilleryProfile()
        {
            CreateMap<Distillery, DistilleryGetResult>();
            CreateMap<WhiskyExpression, DistilleryGetResultWhiskyExpression>()
                  .ForMember(dest => dest.AgeDisplay, opt => opt.MapFrom(src => MonthsToYears.Resolve(src.AgeInMonths)));
            }
    }

    public class DistilleryGetResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool CurrentlyOperating { get; set; }
        public string Region { get; set; }
        public List<DistilleryGetResultWhiskyExpression> WhiskyExpressions { get; set; } = new List<DistilleryGetResultWhiskyExpression>();
    }

    public class DistilleryGetResultWhiskyExpression
    {
        public int Id { get; set; }
        public string AgeDisplay { get; set; }
    }
}