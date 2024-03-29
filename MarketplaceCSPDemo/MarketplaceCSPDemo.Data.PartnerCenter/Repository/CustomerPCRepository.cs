﻿using MarketplaceCSPDemo.Data.PartnerCenter.Context;
using MarketplaceCSPDemo.Data.PartnerCenter.Interfaces;
using Microsoft.Store.PartnerCenter.Models.Agreements;
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

        public Customer Create(Customer customer)
        {
            //Check always domain before create
            var _domainExist = DomainExist(customer.CompanyProfile.Domain);
            if (_domainExist)
                throw new Exception("Domain not valid");

                customer.CompanyProfile.Domain = DomainPreValidation(customer.CompanyProfile.Domain);
                //customer =  _context.aggregatePartner.Customers.Create(customer);
                
                return customer;
         
        }

        public Agreement CreateCustomerAgreement(string customerId)
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

            Agreement agreement = _context.aggregatePartner.Customers.ById(customerId).Agreements.Create(agreementToCreate);
            return agreement;
        }

        public bool DomainExist(string domainPrefix)
        {
            domainPrefix = DomainPreValidation(domainPrefix);

            var _exists = _context.aggregatePartner.Domains.ByDomain(domainPrefix).Exists();
            return _exists;
        }

        public IEnumerable<Customer> GetAll()
        {
            var _customers = _context.aggregatePartner.Customers.Get();

            return _customers.Items;
        }

        private string DomainPreValidation(string domainPrefix)
        {
            if (String.IsNullOrEmpty(domainPrefix))
                return domainPrefix;

            if (!domainPrefix.EndsWith(".onmicrosoft.com"))
                domainPrefix = domainPrefix + ".onmicrosoft.com";

            return domainPrefix;
        }
    }
}
