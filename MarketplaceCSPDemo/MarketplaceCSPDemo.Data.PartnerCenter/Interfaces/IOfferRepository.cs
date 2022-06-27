﻿using Microsoft.Store.PartnerCenter.Models.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceCSPDemo.Core.Interfaces
{
    public interface IOfferRepository
    {
        public IEnumerable<Offer> GetByCountry(string country);
    }
}