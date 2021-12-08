using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillysWacky5.Data.Base;
using WillysWacky5.Models;

namespace WillysWacky5.Data.Services
{
    public class DistributorService : EntityBaseRepository<Distributor>, IDistributorService
    {
      
        public DistributorService(AppDbContext context) : base(context) { }
        
        
    }
}
