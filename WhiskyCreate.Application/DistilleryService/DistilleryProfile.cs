using AutoMapper;
using WhiskyCrate.Application.Contracts.Distilleries;
using WhiskyCrate.Application.Helpers;
using WhiskyCrate.Domain.Distilleries;
using WhiskyCrate.Domain.WhiskyExpressions;

namespace WhiskyCrate.Application.DistilleryService
{
    public class DistilleryProfile : Profile
    {
        public DistilleryProfile()
        {

          CreateMap<Distillery, DistilleryGetDto>();
            CreateMap<WhiskyExpression, DistilleryGetWhiskyExpressionDto>()
                  .ForMember(dest => dest.AgeDisplay, opt => opt.MapFrom(src => MonthsToYears.Resolve(src.AgeInMonths)));
            CreateMap<DistilleryPostRequest, Distillery>();
        }
    }
}