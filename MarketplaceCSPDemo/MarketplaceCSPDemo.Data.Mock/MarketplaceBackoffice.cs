using MarketplaceCSPDemo.Data.Mock.Models;
using MarketplaceCSPDemo.Data.PartnerCenter.Interfaces;
using Microsoft.Store.PartnerCenter.Models.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MarketplaceCSPDemo.Data.Mock
{
    /// <summary>
    /// This class is a mockup.
    /// IT MUST BE REPLACED WITH THE ACTUAL IMPLEMENTATION OF YOUR BACK OFFICE LOGIC
    /// </summary>
    public static class MarketplaceBackoffice
    {
        //Fake price list
        private static List<double> mockPrices = new List<double>()
        {
            150,
            225,
            280.50,
            1000,
            1500.50,
            2000,
            2500,
            850,
            450.4
        };

        public static IEnumerable<MyOffer> GetOffersByCountry(IOfferRepository _offerRepository, string country)
        {
            //Get offers from Marketplace backend
            var _marketplaceOffers = _offerRepository.GetByCountry(country);
            
            //Create a list of mockup objects of type MyOrder, adding fake final prices
            var _myOffers = new List<MyOffer>();
            int i = 0;
            foreach (var item in _marketplaceOffers)
            {
                var myOffer = new MyOffer(item);
                myOffer.FinalPrice = mockPrices[i];
                i++;
                if (i == mockPrices.Count) i = 0;

                _myOffers.Add(myOffer);
            }


            return _myOffers;   
        }
    }
}
