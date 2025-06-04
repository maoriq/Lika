using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CashBalance { get; set; }
        public decimal CardBalance { get; set; }
        public decimal BonusBalance { get; set; }
    }

}
