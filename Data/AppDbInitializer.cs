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

                }
                //Distributor & Products
                if (!context.Distributors_Products.Any())
                {

                }
            }
        }
    }
}
