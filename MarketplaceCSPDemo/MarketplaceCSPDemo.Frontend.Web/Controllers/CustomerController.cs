using MarketplaceCSPDemo.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketplaceCSPDemo.Frontend.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            return View("CustomerIndex");
        }

        public IActionResult CustomerGetAll()
        {
            var _customers = _customerRepository.GetAll();
            return View("_CustomerTable",_customers);
        }

        public IActionResult CustomerCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckDomain(string domainPrefix)
        {
            string _ret = null;
            if(!string.IsNullOrEmpty(domainPrefix) && domainPrefix.Length>3)
                _ret = _customerRepository.DomainExist(domainPrefix).ToString();
            return Json(_ret);
        }

        
    }
}
