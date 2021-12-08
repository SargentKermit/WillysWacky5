using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WillysWacky5.Data;
using WillysWacky5.Data.Base;

namespace WillysWacky5.Models
{
    public class NewProductVM
    {
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product Name Required")]
        public string ProductName { get; set; }
        [Display(Name = "Product Description")]
        [Required(ErrorMessage = "Product Description Required")]
        public string ProductDescription { get; set; }
        [Display(Name = "Product Price (Ex 0.00)")]
        [Required(ErrorMessage = "Product Price Required")]
        
        public double ProductPrice { get; set; }
        [Display(Name = "Product Image URL")]
        [Required(ErrorMessage = "Product Image Required")]
   
        public string ProductImageURL { get; set; }
        [Display(Name = "Product Category")]
        [Required(ErrorMessage = "Product Category Required")]
        public ProductCategory ProductCategory { get; set; }

        //Relationships
        [Display(Name = "Select Distributor(s)")]
        [Required(ErrorMessage = "Distributor Required")]
        public List<int> DistributorIds { get; set; }
        [Display(Name = "Select Warehouse")]
        [Required(ErrorMessage = "Warehouse Required")]
        public int ShipId { get; set; }
        



    }
}
