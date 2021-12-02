using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillysWacky5.Models
{
    public class Distributor_Product
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int DistributorId { get; set; }
        public Distributor  Distributor { get; set; }
    }
}
