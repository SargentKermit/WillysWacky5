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
        public string ShipMapLocationURL { get; set; }
        public string ShipState { get; set; }
        public string ShipAddress { get; set; }
    }
}
