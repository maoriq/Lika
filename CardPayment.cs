using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp
{
    public class CardPayment : IPaymentStrategy
    {
        public string MethodName => "Банковская карта";

        public bool Pay(Customer customer, decimal amount)
        {
            if (customer.CardBalance >= amount)
            {
                customer.CardBalance -= amount;
                return true;
            }
            return false;
        }
    }

}
