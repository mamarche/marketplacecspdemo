using Microsoft.Store.PartnerCenter.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceCSPDemo.Data.PartnerCenter.Interfaces
{
    public interface IOrderRepository
    {
        Order CreateOrder(Order order);
        IEnumerable<Order> GetByCustomerId(string customerId);
    }
}
