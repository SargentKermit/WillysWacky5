using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillysWacky5.Models;

namespace WillysWacky5.Data.Services
{
    public class DistributorService : IDistributorService
    {
        private readonly AppDbContext _context;
        public DistributorService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Distributor distributor)
        {
            await _context.Distributors.AddAsync(distributor);
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Distributor>> GetAllAsync()
        {
            var result = await _context.Distributors.ToListAsync();
            return result;
        }

        public async Task<Distributor> GetByIdAsync(int id)
        {
            var result = await _context.Distributors.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public Distributor Update(int id, Distributor newDistributor)
        {
            throw new NotImplementedException();
        }
    }
}
