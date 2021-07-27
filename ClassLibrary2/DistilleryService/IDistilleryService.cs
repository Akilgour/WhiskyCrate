using System.Collections.Generic;
using System.Threading.Tasks;
using WhiskyCrate.Application.Contracts.Distilleries;

namespace WhiskyCrate.Application.Contracts.DistilleryService
{
    public interface IDistilleryService
    {
        Task<IEnumerable<DistilleryGetListDto>> GetDistilleries();

        Task<DistilleryGetDto> GetDistillery(int id);
        Task<DistilleryGetDto> AddDistillery(DistilleryPostRequest distillery);
        Task<bool> DeleteDistillery(int id);
    }
}