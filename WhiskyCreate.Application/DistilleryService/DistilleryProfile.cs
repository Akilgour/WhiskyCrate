using AutoMapper;
using WhiskyCrate.Application.Contracts.Distilleries;
using WhiskyCrate.Domain.Distilleries;

namespace WhiskyCrate.Application.DistilleryService
{
    public class DistilleryProfile : Profile
    {
        public DistilleryProfile()
        {
            CreateMap<Distillery, DistilleryGetListDto>();

        }
    }
}