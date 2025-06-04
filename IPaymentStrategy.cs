using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp
{
    public interface IPaymentStrategy
    {
        bool Pay(Customer customer, decimal amount);
        string MethodName { get; }
    }

}
