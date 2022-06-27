using MarketplaceCSPDemo.Core.Interfaces;
using MarketplaceCSPDemo.Data.PartnerCenter.Interfaces;
using MarketplaceCSPDemo.Frontend.Web.Models;
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
            return View("_CustomerTable", _customers);
        }

        public IActionResult CustomerCreate(string offerId,string offerName)
        {
            ViewBag.OfferId = offerId;
            ViewBag.OfferName = offerName;

            return View();
        }

        public IActionResult CreateSave(CustomerDTO customerDTO)
        {
            try
            {
                //Parsing to Partner Center API Customer Model
                Microsoft.Store.PartnerCenter.Models.Customers.Customer _customer = new Microsoft.Store.PartnerCenter.Models.Customers.Customer();
                _customer.CompanyProfile = new Microsoft.Store.PartnerCenter.Models.Customers.CustomerCompanyProfile { Domain = customerDTO.Domain };
                _customer.BillingProfile = new Microsoft.Store.PartnerCenter.Models.Customers.CustomerBillingProfile
                {
                    Culture = customerDTO.Culture,
                    CompanyName = customerDTO.CompanyName,
                    Email = customerDTO.Email,
                    Language = customerDTO.Language,
                    DefaultAddress = new Microsoft.Store.PartnerCenter.Models.Address
                    {
                        FirstName = customerDTO.FirstName,
                        LastName = customerDTO.LastName,
                        City = customerDTO.City,
                        State = customerDTO.State,
                        Country = customerDTO.Country,
                        PostalCode = customerDTO.PostalCode,
                        AddressLine1 = customerDTO.Addressline1
                    }
                };

                var _result = _customerRepository.Create(_customer);
                customerDTO.StatusMessage = "success";
                customerDTO.User = _result.UserCredentials?.UserName;
                customerDTO.Password = _result.UserCredentials?.Password;
            }
            catch(Exception ex)
            {
                customerDTO.StatusMessage = ex.Message;
            }
           



            return Json(customerDTO);
        }

        [HttpPost]
        public IActionResult CheckDomain(string domainPrefix)
        {
            bool _ret = true;

            if (!string.IsNullOrEmpty(domainPrefix) && domainPrefix.Length > 3)
            {
                try
                {
                    _ret = _customerRepository.DomainExist(domainPrefix);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }


            return Json(_ret);
        }


    }
}
