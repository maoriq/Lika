using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp
{
    public class BonusPayment : IPaymentStrategy
    {
        public string MethodName => "Бонусы";

        public bool Pay(Customer customer, decimal amount)
        {
            if (customer.BonusBalance >= amount)
            {
                customer.BonusBalance -= amount;
                return true;
            }
            return false;
        }
    }

}
