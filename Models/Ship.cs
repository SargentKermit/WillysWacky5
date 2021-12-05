using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WillysWacky5.Models
{
    public class Ship
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Shipping From")]
        public string ShipMapLocationURL { get; set; }
        [Display(Name = "Shipping State")]
        public string ShipState { get; set; }
        [Display(Name = "Warehouse Address")]
        public string ShipAddress { get; set; }

        //Relationships
        public List<Product> Product { get; set; }
    }
}
