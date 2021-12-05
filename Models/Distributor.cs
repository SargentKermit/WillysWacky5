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

        [Display(Name = "Distributor Logo")]
        public string DistributorLogoURL { get; set; }
        [Display(Name = "Name")]
        public string DistributorName { get; set; }
        [Display(Name = "Address")]
        public string DistributorAddress { get; set; }

        //Relationships
        public List<Distributor_Product> Distributor_Products { get; set; }
    }
}
