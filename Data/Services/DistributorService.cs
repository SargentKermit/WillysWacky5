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
        public void Add(Distributor distributor)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Distributor>> GetAll()
        {
            var result = await _context.Distributors.ToListAsync();
            return result;
        }

        public Distributor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Distributor Update(int id, Distributor newDistributor)
        {
            throw new NotImplementedException();
        }
    }
}
