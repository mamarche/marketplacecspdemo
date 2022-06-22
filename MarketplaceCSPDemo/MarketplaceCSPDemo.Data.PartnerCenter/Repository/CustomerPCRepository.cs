using MarketplaceCSPDemo.Core.Interfaces;
using MarketplaceCSPDemo.Core.Models;
using MarketplaceCSPDemo.Data.PartnerCenter.Context;
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


            List<Customer> _ret = new List<Customer>();
            foreach (var item in _customers.Items)
            {
                _ret.Add(new Customer
                {
                    Id = item.Id,
                    Name = item.CompanyProfile.CompanyName
                });
            }

            return _ret;
        }
    }
}
