using System.Collections.Generic;
using System.Threading.Tasks;
using WhiskyCrate.Application.Contracts.Distilleries;
using WhiskyCrate.Domain.Distilleries;

namespace WhiskyCrate.Application.Contracts.DistilleryService
{
    public interface IDistilleryService
    {
        Task<IEnumerable<Distillery>> GetDistilleries();

        Task<DistilleryGetDto> GetDistillery(int id);
        Task<DistilleryGetDto> AddDistillery(DistilleryPostRequest distillery);
        Task<bool> DeleteDistillery(int id);
        Task<bool> DistilleryExists(int id);
        Task<DistilleryGetDto> UpdateDistillery(DistilleryPutRequest distillery);
    }
}