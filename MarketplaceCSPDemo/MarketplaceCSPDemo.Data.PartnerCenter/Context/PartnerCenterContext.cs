using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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
        public readonly IOptions<PartnerCenterOptions> _options;

        public PartnerCenterContext(IOptions<PartnerCenterOptions> options)
        {
            _options = options;
            aggregatePartner = GetAggregatePartner();
        }

        private IAggregatePartner GetAggregatePartner()
        {
            var partnerCredentials = PartnerCredentials.Instance.GenerateByApplicationCredentials(_options.Value.ClientId, _options.Value.ClientSecret,_options.Value.AppDomain);
            
            return PartnerService.Instance.CreatePartnerOperations(partnerCredentials);

        }
    }
}
