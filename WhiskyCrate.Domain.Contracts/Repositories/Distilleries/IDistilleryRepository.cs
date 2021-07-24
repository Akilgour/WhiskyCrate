using System.Collections.Generic;
using System.Threading.Tasks;
using WhiskyCrate.Domain.Distilleries;

namespace WhiskyCrate.Data.Contracts.Repositories.Distilleries
{
    public interface IDistilleryRepository
    {
        Task<IEnumerable<Distillery>> GetDistilleries();
    }
}