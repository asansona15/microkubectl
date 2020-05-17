using Microservice.ECommerce.OrderApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice.ECommerce.OrderApp.Repository
{
    public class MemoryOrder
    {
        IList<Order> orders = new List<Order>();

        public MemoryOrder()
        {
            orders.Add(new Order { OrderId = 1, OrderAmount = 250.00, OrderDate = new DateTime(2020, 04, 14) });
            orders.Add(new Order { OrderId = 2, OrderAmount = 450.00, OrderDate = new DateTime(2020, 04, 15) });
        }

        public IEnumerable<Order> GetOrders()
        {
            return this.orders;
        }
    }
}
