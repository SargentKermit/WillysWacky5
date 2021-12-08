using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WillysWacky5.Data.Base;

namespace WillysWacky5.Models
{
    public class Distributor:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Distributor Logo")]
        [Required(ErrorMessage = "Distributor Logo Required")]
        public string DistributorLogoURL { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Distributor Name Required")]
        public string DistributorName { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Distributor Address Required")]
        public string DistributorAddress { get; set; }

        //Relationships
        public List<Distributor_Product> Distributor_Products { get; set; }
    }
}
