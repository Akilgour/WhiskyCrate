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
        Task<GetDistilleryResult> GetDistillery(int id);
    }

    public class GetDistilleryManager : IGetDistilleryManager
    {
        private readonly IDistilleryService distilleryService;
        private readonly IMapper mapper;

        public GetDistilleryManager(IDistilleryService distilleryService, IMapper mapper)
        {
            this.distilleryService = distilleryService;
            this.mapper = mapper;
        }

        public async Task<GetDistilleryResult> GetDistillery(int id)
        {
            return mapper.Map<GetDistilleryResult>(await distilleryService.GetDistillery(id));
        }
    }

    public class GetDistilleryProfile : Profile
    {
        public GetDistilleryProfile()
        {
            CreateMap<Distillery, GetDistilleryResult>();
            CreateMap<WhiskyExpression, GetDistilleryResultWhiskyExpression>()
                  .ForMember(dest => dest.AgeDisplay, opt => opt.MapFrom(src => MonthsToYears.Resolve(src.AgeInMonths)));
            }
    }

    public class GetDistilleryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool CurrentlyOperating { get; set; }
        public string Region { get; set; }
        public List<GetDistilleryResultWhiskyExpression> WhiskyExpressions { get; set; } = new List<GetDistilleryResultWhiskyExpression>();
    }

    public class GetDistilleryResultWhiskyExpression
    {
        public int Id { get; set; }
        public string AgeDisplay { get; set; }
    }
}