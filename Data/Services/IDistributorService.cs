using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillysWacky5.Models;

namespace WillysWacky5.Data.Services
{
    public interface IDistributorService
    {
        Task<IEnumerable<Distributor>> GetAllAsync();
        Task<Distributor> GetByIdAsync(int id);
        Task AddAsync(Distributor distributor);
        Distributor Update(int id, Distributor newDistributor);
        void Delete(int id);
    }
}
