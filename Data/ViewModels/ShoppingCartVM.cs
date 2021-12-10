using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillysWacky5.Data.Cart;

namespace WillysWacky5.Data.ViewModels
{
    public class ShoppingCartVM
    {
        public ShoppingCart ShoppingCart { get; set; }
        public double ShoppingCartTotal { get; set; }
    }
}
