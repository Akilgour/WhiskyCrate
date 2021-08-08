using System.Collections.Generic;
using System.Threading.Tasks;
using WhiskyCrate.Domain.Distilleries;

namespace WhiskyCrate.Application.Contracts.DistilleryService
{
    public interface IDistilleryService
    {
        Task<IEnumerable<Distillery>> GetDistilleries();

        Task<Distillery> GetDistillery(int id);

        Task AddDistillery(Distillery distillery);

        Task<bool> DeleteDistillery(int id);

        Task<bool> DistilleryExists(int id);

        Task UpdateDistillery(Distillery distillery);
    }
}