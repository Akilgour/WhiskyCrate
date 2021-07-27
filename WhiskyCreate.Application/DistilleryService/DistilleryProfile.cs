using AutoMapper;
using WhiskyCrate.Application.Contracts.Distilleries;
using WhiskyCrate.Domain.Distilleries;
using WhiskyCrate.Domain.WhiskyExpressions;

namespace WhiskyCrate.Application.DistilleryService
{
    public class DistilleryProfile : Profile
    {
        public DistilleryProfile()
        {
            CreateMap<Distillery, DistilleryGetListDto>();

            CreateMap<Distillery, DistilleryGetDto>();
            CreateMap<WhiskyExpression, DistilleryGetWhiskyExpressionDto>();

        }
    }
}