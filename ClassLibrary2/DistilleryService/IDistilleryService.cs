using System.Collections.Generic;
using System.Threading.Tasks;
using WhiskyCrate.Domain.Distilleries;

namespace WhiskyCrate.Application.Contracts.DistilleryService
{
    public interface IDistilleryService
    {
        Task<IEnumerable<Distillery>> GetDistilleries();
    }
}