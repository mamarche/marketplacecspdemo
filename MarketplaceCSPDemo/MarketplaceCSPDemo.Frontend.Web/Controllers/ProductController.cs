using MarketplaceCSPDemo.Data.PartnerCenter.Context;
using MarketplaceCSPDemo.Data.PartnerCenter.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketplaceCSPDemo.Frontend.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View("ProductIndex");
        }

        public IActionResult GetOrderByTargetAndSegment(string country,string target,string segment)
        {
            var _products = _productRepository.GetOrderByTargetAndSegment(country, target, segment);
            return View("_ProductTable", _products);
        }
    }
}
