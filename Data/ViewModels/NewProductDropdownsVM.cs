using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillysWacky5.Models;

namespace WillysWacky5.Data.ViewModels
{
    public class NewProductDropdownsVM
    {
        public NewProductDropdownsVM()
        {
            Ships = new List<Ship>();
            Distributors = new List<Distributor>();

        }
        public List<Ship> Ships { get; set; }
        public List<Distributor> Distributors { get; set; }

    }
}
