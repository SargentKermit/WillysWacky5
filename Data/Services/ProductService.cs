using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillysWacky5.Data.Base;
using WillysWacky5.Models;

namespace WillysWacky5.Data.Services
{
    public class ProductService: EntityBaseRepository<Product>, IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var productDetails = _context.Products
                .Include(s => s.Ship)
                .Include(dp => dp.Distributor_Products).ThenInclude(d => d.Distributor)
                .FirstOrDefaultAsync(n => n.Id == id);
            return await productDetails;
        }
    }
}
