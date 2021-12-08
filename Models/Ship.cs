using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WillysWacky5.Data.Base;

namespace WillysWacky5.Models
{
    public class Ship:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Shipping From")]
        [Required(ErrorMessage = "Warehouse Map Location Required")]
        public string ShipMapLocationURL { get; set; }
        [Display(Name = "Shipping State")]
        [Required(ErrorMessage = "Warehouse State Required")]
        public string ShipState { get; set; }
        [Display(Name = "Warehouse Address")]
        [Required(ErrorMessage = "Warehouse Address Required")]
        public string ShipAddress { get; set; }

        //Relationships
        public List<Product> Product { get; set; }
    }
}
