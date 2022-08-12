using MarketplaceCSPDemo.Data.PartnerCenter.Interfaces;
using MarketplaceCSPDemo.Frontend.Customer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Store.PartnerCenter.Models.Offers;
using Microsoft.Store.PartnerCenter.Models.Orders;

namespace MarketplaceCSPDemo.Frontend.Customer.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IConfiguration _configuration;
        public OrderController(ICustomerRepository customerRepository, IConfiguration configuration,IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View("OrderIndex");
        }

        public IActionResult OrderCreate(string offerId, string offerName, string offerFinalPrice)
        {
            
            ViewBag.offerId = offerId;
            ViewBag.offerName = offerName;
            ViewBag.offerFinalPrice = offerFinalPrice;

            Order _ret = new Order();

            return View(_ret);
        }

        public IActionResult GetOrdersByCustomerId(string customerId)
        {
            var _orders = _orderRepository.GetByCustomerId(customerId);
            return View("_OrderTable", _orders);
        }

        [HttpPost]
        public IActionResult OrderCreateSave(OrderDTO order)
        {
            //TODO: Save order to the actual back office

            //Use demo customer
            //TODO: Get the real customer id from back office
            order.ReferenceCustomerId = _configuration.GetSection("DemoCustomerId").Value;

            //Create the order in Marketpalce
            Order _order = new Order
            {
                ReferenceCustomerId = order.ReferenceCustomerId,
                BillingCycle =(BillingCycleType)Enum.Parse(typeof(BillingCycleType), order.BillingCycle,true),
                LineItems =  new List<OrderLineItem>()
                {
                     new OrderLineItem()
                    {
                        OfferId = order.OfferId,
                        FriendlyName = "new offer purchase",
                        Quantity = order.Quantity
                    }
                }

            };

            try
            {
                var result = _orderRepository.CreateOrder(_order);
                order.StatusMessage = "success";
            }catch(Exception ex)
            {
                order.StatusMessage = ex.Message;
            }

            return Json(order);
        }

     




    }
}
