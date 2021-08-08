using AutoMapper;
using System.Threading.Tasks;
using WhiskyCrate.Application.Contracts.DistilleryService;
using WhiskyCrate.Domain.Distilleries;

namespace WhiskyCrate.API.Managers
{
    public interface IDistilleryPutManager
    {
        Task UpdateDistillery(DistilleryPutRequest distilleryPutRequest);
    }

    public class DistilleryPutManager : IDistilleryPutManager
    {
        private readonly IDistilleryService distilleryService;
        private readonly IMapper mapper;

        public DistilleryPutManager(IDistilleryService distilleryService, IMapper mapper)
        {
            this.distilleryService = distilleryService;
            this.mapper = mapper;
        }

        public async Task UpdateDistillery(DistilleryPutRequest distilleryPutRequest)
        {
            var itemToUpdate = mapper.Map<Distillery>(distilleryPutRequest);
            var itemFromDB = await distilleryService.GetDistillery(distilleryPutRequest.Id);
            var updatedItem = mapper.Map( itemFromDB, itemToUpdate);
            await distilleryService.UpdateDistillery(updatedItem);
        }
    }

    public class DistilleryPutProfile : Profile
    {
        public DistilleryPutProfile()
        {
            CreateMap<DistilleryPutRequest, Distillery>();
        }
    }

    public class DistilleryPutRequest
    {
        public string Name { get; set; }
        public bool CurrentlyOperating { get; set; }
        public string Region { get; set; }
        public int Id { get; set; }
    }
}