using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillysWacky5.Models;

namespace WillysWacky5.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelbuilder) 
        {
            modelbuilder.Entity<Distributor_Product>().HasKey(dp => new
            {
                dp.DistributorId,
                dp.ProductId
            });
            modelbuilder.Entity<Distributor_Product>().HasOne(p => p.Product).WithMany(dp => dp.Distributor_Products).HasForeignKey(p => p.ProductId);
            modelbuilder.Entity<Distributor_Product>().HasOne(p => p.Distributor).WithMany(dp => dp.Distributor_Products).HasForeignKey(p => p.DistributorId);
            base.OnModelCreating(modelbuilder);
        }
        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Distributor_Product> Distributor_Products { get; set; }
        public DbSet<Ship> Ships { get; set; }


        //Order related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
