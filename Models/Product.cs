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
    public class Product:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public string ProductImageURL { get; set; }

        public ProductCategory ProductCategory { get; set; }

        //Relationships
        public List<Distributor_Product> Distributor_Products { get; set; }

        //Ship
        public int ShipId { get; set; }
        [ForeignKey("ShipId")]
        public Ship Ship { get; set; }



    }
}
