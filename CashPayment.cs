using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp
{
    public class CashPayment : IPaymentStrategy
    {
        public string MethodName => "Наличные";

        public bool Pay(Customer customer, decimal amount)
        {
            if (customer.CashBalance >= amount)
            {
                customer.CashBalance -= amount;
                return true;
            }
            return false;
        }
    }

}
