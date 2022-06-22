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
           
           
            List<Offer> _ret = new List<Offer>();
            foreach(var item in _offers.Items)
            {
                _ret.Add(new Offer { 
                    Id=item.Id,
                    Description=item.Description,
                    Name = item.Name
                });
            }

            return _ret;

           
        }
    }
}
