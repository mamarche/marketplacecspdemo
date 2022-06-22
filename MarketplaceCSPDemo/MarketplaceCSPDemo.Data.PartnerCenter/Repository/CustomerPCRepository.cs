using MarketplaceCSPDemo.Core.Interfaces;
using MarketplaceCSPDemo.Data.PartnerCenter.Context;
using MarketplaceCSPDemo.Data.PartnerCenter.Interfaces;
using Microsoft.Store.PartnerCenter.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceCSPDemo.Data.PartnerCenter.Repository
{
    public class CustomerPCRepository : ICustomerRepository
    {
        private readonly PartnerCenterContext _context;
        public CustomerPCRepository(PartnerCenterContext context)
        {
            _context = context;
        }

        public bool DomainExist(string domainPrefix)
        {
            if (!domainPrefix.EndsWith(".onmicrosoft.com"))
                domainPrefix = domainPrefix + ".onmicrosoft.com";

            var _exists = _context.aggregatePartner.Domains.ByDomain(domainPrefix).Exists();
            return _exists;
        }

        public IEnumerable<Customer> GetAll()
        {
            var _customers = _context.aggregatePartner.Customers.Get();

            return _customers.Items;
        }
    }
}
