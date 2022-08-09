using MarketplaceCSPDemo.Data.Mock;
using MarketplaceCSPDemo.Data.PartnerCenter.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketplaceCSPDemo.Frontend.Customer.Controllers
{
    public class OfferController : Controller
    {

        private IOfferRepository _offerRepository;

        public OfferController(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public IActionResult Index()
        {
            return View("OfferIndex");
        }

        public IActionResult GetOffersByCountry(string country)
        {
            var _offers =  MarketplaceBackoffice.GetOffersByCountry(_offerRepository, country);

            return View("_OfferTable",_offers);
        }

        public IActionResult Get(string offerId,string country,bool isAddon)
        {
            var _offer = _offerRepository.GetOffer(offerId, country, isAddon);
            return Json(_offer);
        }
    }
}
