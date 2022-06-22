using MarketplaceCSPDemo.Core.Interfaces;
using MarketplaceCSPDemo.Data.PartnerCenter.Context;
using Microsoft.Store.PartnerCenter.Models.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceCSPDemo.Data.PartnerCenter.Repository
{
    public class OfferPCRepository : IOfferRepository
    {

        private readonly PartnerCenterContext _context;
        public OfferPCRepository(PartnerCenterContext context)
        {
            _context = context;
        }

        public IEnumerable<Offer> GetByCountry(string country)
        {
            var _offers = _context.aggregatePartner.Offers.ByCountry(country).Get();

            return _offers.Items;
        }
    }
}
