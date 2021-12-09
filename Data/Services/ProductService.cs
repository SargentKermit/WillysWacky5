using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillysWacky5.Data.Base;
using WillysWacky5.Data.ViewModels;
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
        public async Task AddNewProductAsync(NewProductVM data)
        {
            var newProduct = new Product()
            {
                ProductName = data.ProductName,
                ProductDescription = data.ProductDescription,
                ProductPrice = data.ProductPrice,
                ProductImageURL = data.ProductImageURL,
                ShipId = data.ShipId,
                ProductCategory = data.ProductCategory
            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            //Add Product Distributors
            foreach (var distributorId in data.DistributorIds)
            {
                var newDistributorProduct = new Distributor_Product()
                {
                    ProductId = newProduct.Id,
                    DistributorId = distributorId
                };
                await _context.Distributor_Products.AddAsync(newDistributorProduct);
            }
            await _context.SaveChangesAsync();
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            var productDetails = _context.Products
                .Include(s => s.Ship)
                .Include(dp => dp.Distributor_Products).ThenInclude(d => d.Distributor)
                .FirstOrDefaultAsync(n => n.Id == id);
            return await productDetails;
        }

        public  async Task<NewProductDropdownsVM> GetNewProductDropdownsValues()
        {
            var response = new NewProductDropdownsVM()
            {
                Distributors = await _context.Distributors.OrderBy(n => n.DistributorName).ToListAsync(),
               Ships = await _context.Ships.OrderBy(n => n.ShipAddress).ToListAsync()
            };
            return response;
        }

        public async Task UpdateProductAsync(NewProductVM data)
        {
            var dbProduct = await _context.Products.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbProduct != null)
            {
                dbProduct.ProductName = data.ProductName;
                dbProduct.ProductDescription = data.ProductDescription;
                dbProduct.ProductPrice = data.ProductPrice;
                dbProduct.ProductImageURL = data.ProductImageURL;
                dbProduct.ShipId = data.ShipId;
                dbProduct.ProductCategory = data.ProductCategory;
                await _context.SaveChangesAsync();
            }
            //Remove existing actors
            var existingProductsDb = _context.Distributor_Products.Where(n => n.ProductId == data.Id).ToList();
             _context.Distributor_Products.RemoveRange(existingProductsDb);
            await _context.SaveChangesAsync();
            //Add Product Distributors
            foreach (var distributorId in data.DistributorIds)
            {
                var newDistributorProduct = new Distributor_Product()
                {
                    ProductId = data.Id,
                    DistributorId = distributorId
                };
                await _context.Distributor_Products.AddAsync(newDistributorProduct);
            }
            await _context.SaveChangesAsync();
        }
    }
}
