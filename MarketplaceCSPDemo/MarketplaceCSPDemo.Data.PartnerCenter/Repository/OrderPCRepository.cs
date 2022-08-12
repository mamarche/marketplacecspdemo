using MarketplaceCSPDemo.Data.PartnerCenter.Context;
using MarketplaceCSPDemo.Data.PartnerCenter.Interfaces;
using Microsoft.Store.PartnerCenter.Models.Agreements;
using Microsoft.Store.PartnerCenter.Models.Carts;
using Microsoft.Store.PartnerCenter.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceCSPDemo.Data.PartnerCenter.Repository
{
    public class OrderPCRepository : IOrderRepository
    {
        private readonly PartnerCenterContext _context;
        public OrderPCRepository(PartnerCenterContext context)
        {
            _context = context;
        }
        public Order CreateOrder(Order order)
        {

            var _result = _context.aggregatePartner.Customers.ById(order.ReferenceCustomerId).Orders.Create(order);
            return _result;
        }

        public IEnumerable<Order> GetByCustomerId(string customerId)
        {

            var _customers = _context.aggregatePartner.Customers.Get();
            var _orders = _context.aggregatePartner.Customers.ById(customerId).Orders.Get().Items.ToList();

            return _orders;
        }
    }
}
