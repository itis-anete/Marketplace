using System;
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

        public void AddNewOrder(Cart cart)
        {
            var newOrder = new Order(
                cart.Customer.Login, 
                cart.Products, 
                cart.TotalInUsDollarsWithoutDiscounts);

            applicationContext.Orders.Add(newOrder);

            cart.Reset();
            applicationContext.Carts.Update(cart);
            
            applicationContext.SaveChanges();
        }

        public IEnumerable<Order> GetAllCustomerOrders(string customerLogin)
        {
            return applicationContext.Orders
                .Where(order => string.Equals(order.CustomerLogin,
                    customerLogin,
                    StringComparison.InvariantCultureIgnoreCase));
        }
    }
}