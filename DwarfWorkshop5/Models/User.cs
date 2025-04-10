﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwarfWorkshop5.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public double Gold { get; set; }

        public double TotalSale { get; set; }

        public int TokenAmount { get; set; }

        public int Lvl { get; set; } = 1;

        public DateTime LastSave { get; set; }
    }
}
