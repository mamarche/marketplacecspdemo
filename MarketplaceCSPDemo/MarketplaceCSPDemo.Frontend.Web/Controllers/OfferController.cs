using MarketplaceCSPDemo.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketplaceCSPDemo.Frontend.Web.Controllers
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
            var _offers = _offerRepository.GetByCountry(country);

            return View("OfferList",_offers);
        }
    }
}
