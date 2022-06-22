using Microsoft.Store.PartnerCenter.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceCSPDemo.Data.PartnerCenter.Interfaces
{
    public interface ICustomerRepository
    {
        public IEnumerable<Customer> GetAll();
        public bool DomainExist(string domainPrefix);
    }
}
