using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WillysWacky5.Models
{
    public class Distributor
    {
        [Key]
        public int Id { get; set; }
        public string DistributorLogoURL { get; set; }
        public string DistributorName { get; set; }
        public string DistributorAddress { get; set; }

        //Relationships
        public List<Distributor_Product> Distributor_Products { get; set; }
    }
}
