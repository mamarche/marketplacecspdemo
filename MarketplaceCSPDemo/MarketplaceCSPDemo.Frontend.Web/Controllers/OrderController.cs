using MarketplaceCSPDemo.Data.PartnerCenter.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Store.PartnerCenter.Models.Offers;
using Microsoft.Store.PartnerCenter.Models.Orders;

namespace MarketplaceCSPDemo.Frontend.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IConfiguration _configuration;
        public OrderController(ICustomerRepository customerRepository, IConfiguration configuration)
        {
            _customerRepository = customerRepository;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View("OrderIndex");
        }

        public IActionResult OrderCreate(Guid offerId,string offerName)
        {
            //Get all customer to avoid customer creation
            var _customers = _customerRepository.GetAll();
            ViewBag.customers = _customers;
            ViewBag.offerId = offerId;
            ViewBag.offerName = offerName;


            Order _ret = new Order
            {
                ReferenceCustomerId = _configuration.GetSection("DemoCustomerId").Value
            };

            return View(_ret);
        }
    }
}
