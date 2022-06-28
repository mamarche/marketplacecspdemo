using MarketplaceCSPDemo.Data.PartnerCenter.Context;
using MarketplaceCSPDemo.Data.PartnerCenter.Interfaces;
using Microsoft.Store.PartnerCenter.Models.Agreements;
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
            string agreementType = "MicrosoftCustomerAgreement";

            var microsoftCustomerAgreementDetails = _context.aggregatePartner.AgreementDetails.ByAgreementType(agreementType).Get().Items.Single();

            // string selectedCustomerId;

            var agreementToCreate = new Agreement
            {
                DateAgreed = DateTime.UtcNow,
                TemplateId = microsoftCustomerAgreementDetails.TemplateId,
                PrimaryContact = new Contact
                {
                    FirstName = "Test",
                    LastName = "MS",
                    Email = "someone@example.com",
                    PhoneNumber = "1234567890"
                }
            };

            //Agreement agreement = _context.aggregatePartner.Customers.ById(customerId).Agreements.Create(agreementToCreate);

            var _customers = _context.aggregatePartner.Customers.Get();
            var _orders = _context.aggregatePartner.Customers.ById(customerId).Orders.Get().Items.ToList();
            //foreach (var item in _customers.Items)
            //{
            //    _orders.AddRange(_context.aggregatePartner.Customers.ById(item.Id).Orders.Get().Items);
            //}



            return _orders;
        }
    }
}
