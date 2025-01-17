﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WhiskyCrate.Domain.Distilleries;

namespace WhiskyCrate.Data.Contracts.Repositories.Distilleries
{
    public interface IDistilleryRepository
    {
        Task<IEnumerable<Distillery>> GetDistilleries();
        Task<Distillery> GetDistillery(int id);
        Task<Distillery> AddDistillery(Distillery distillery);
        Task<bool> DeleteDistillery(int id);
        Task<bool> DistilleryExists(int id);
        Task UpdateDistillery(Distillery distillery);
    }
}