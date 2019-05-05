using System.Linq;
using Marketplace.Core;
using Marketplace.DbAccess;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult MakeOrder(string customerLogin)
        {
            if (string.IsNullOrWhiteSpace(customerLogin))
            {
                return BadRequest();
            }
            
            var cart = unitOfWork.CartRepository.GetCustomerCart(customerLogin);

            if (cart == null)
            {
                return NotFound();
            }
            
            unitOfWork.OrderRepository.AddNewOrder(cart);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllCustomerOrders(string customerLogin)
        {
            var orders = unitOfWork.OrderRepository.GetAllCustomerOrders(customerLogin);

            if (!orders.Any())
            {
                return NotFound();
            }

            return Ok(orders);
        }
    }
}