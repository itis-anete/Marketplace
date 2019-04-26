using System.Collections.Generic;
using System.Linq;
using Marketplace.Core;

namespace Marketplace.DbAccess
{
    internal class PgOrderRepository : PgRepositoryBase, IOrderRepository
    {
        public PgOrderRepository(ApplicationContext applicationContext)
            : base(applicationContext)
        {
        }

        public void MakeOrder(Cart cart, Address deliveryAddress = null)
        {
            var newOrder = new Order(
                cart.Customer, 
                cart.Products, 
                cart.TotalInUsDollarsWithoutDiscounts,
                deliveryAddress);

            applicationContext.Orders.Add(newOrder);
            applicationContext.SaveChanges();
        }

        public IEnumerable<Order> GetAllCustomerOrders(Customer customer)
        {
            return applicationContext.Orders
                .Where(order => order.Customer.Equals(customer));
        }
    }
}