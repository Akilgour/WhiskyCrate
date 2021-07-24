using System.Collections.Generic;
using System.Threading.Tasks;
using WhiskyCrate.Domain.Distillery;

namespace WhiskyCrate.Application.Contracts.DistilleryService
{
    public interface IDistilleryService
    {
        Task<IEnumerable<Distillery>> GetDistilleries();
    }
}