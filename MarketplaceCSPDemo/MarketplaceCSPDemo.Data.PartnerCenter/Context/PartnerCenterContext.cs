using Microsoft.Store.PartnerCenter;
using Microsoft.Store.PartnerCenter.Agreements;
using Microsoft.Store.PartnerCenter.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceCSPDemo.Data.PartnerCenter.Context
{
    public class PartnerCenterContext
    {
        public IAggregatePartner aggregatePartner { get; set; }

        public PartnerCenterContext()
        {
            aggregatePartner = GetAggregatePartner();
        }

        private IAggregatePartner GetAggregatePartner()
        {
            var partnerCredentials = PartnerCredentials.Instance.GenerateByApplicationCredentials("[YOUR CLIENT ID HERE]", "[YOUR SECRET HERE]", "[YOUR DOMAIN HERE]");
            
            return PartnerService.Instance.CreatePartnerOperations(partnerCredentials);

        }
    }
}
