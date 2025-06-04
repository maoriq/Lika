using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double? Weight { get; set; }

        public decimal TotalPrice
        {
            get
            {
                if (Product.IsWeighted && Weight.HasValue)
                    return (decimal)Weight.Value * Product.Price;
                return Quantity * Product.Price;
            }
        }
    }

}
