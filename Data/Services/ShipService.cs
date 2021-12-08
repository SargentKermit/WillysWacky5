﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillysWacky5.Data.Base;
using WillysWacky5.Models;

namespace WillysWacky5.Data.Services
{
    public class ShipService:EntityBaseRepository<Ship>, IShipService
    {
        public ShipService(AppDbContext context) : base(context)
        {

        }
    }
}
