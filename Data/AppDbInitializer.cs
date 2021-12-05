using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillysWacky5.Models;

namespace WillysWacky5.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Ship
                if (!context.Ships.Any())
                {
                    context.Ships.AddRange(new List<Ship>()
                    {
                        new Ship()
                        {
                            ShipState = "Wisconsin",
                            ShipAddress = "3535 Weeden Creek Rd, Sheboygan, WI 53081",
                            ShipMapLocationURL = "http://reinemannc-ltc.com/2021-ltc-classes/WillysWackyImages/sheboyganFedEx.png"

                        }
                    });
                    context.SaveChanges();
                }
                //Distributor
                if (!context.Distributors.Any())
                {
                    context.Distributors.AddRange(new List<Distributor>()
                    {
                        new Distributor()
                        {
                            DistributorName = "Joseph's Distributing",
                            DistributorAddress = "75 Columbia Drive Wheaton, IL 60187",
                            DistributorLogoURL = "http://reinemannc-ltc.com/2021-ltc-classes/WillysWackyImages/josephsDistributing.png"

                        }
                    });
                    context.SaveChanges();
                }
                //Product
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            ProductName = "Sea Weed Cheese",
                            ProductDescription = "Cheese that tastes like seafood and is green in color.",
                            ProductPrice = 3.99,
                            ProductImageURL = "http://reinemannc-ltc.com/2021-ltc-classes/images/seacheese.jpg",
                            ProductCategory = ProductCategory.Food,
                            ShipId = 1


                        }

                    });
                    context.SaveChanges();

                }
                //Distributor & Products
                if (!context.Distributor_Products.Any())
                {
                    context.Distributor_Products.AddRange(new List<Distributor_Product>()
                    {
                        new Distributor_Product()
                        {
                            ProductId = 3,
                            DistributorId = 1


                        }
                    });
                    context.SaveChanges();

                }
            }
        }
    }
}
