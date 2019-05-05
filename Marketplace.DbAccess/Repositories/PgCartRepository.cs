using System;
using System.Linq;
using Marketplace.Core;

namespace Marketplace.DbAccess
{
    internal class PgCartRepository : PgRepositoryBase, ICartRepository
    {
        public PgCartRepository(ApplicationContext applicationContext) 
            : base(applicationContext)
        {
        }
        
        public Cart GetCustomerCart(string customerLogin)
        {
            bool IsCartBelongsToCustomer(Cart cart)
            {
                return string.Equals(
                    cart.Customer.Login,
                    customerLogin,
                    StringComparison.InvariantCultureIgnoreCase);
            }

            return applicationContext.Carts
                .FirstOrDefault(IsCartBelongsToCustomer);
        }

        public void UpdateCart(Cart updatedCart)
        {
            applicationContext.Carts.Update(updatedCart);
            applicationContext.SaveChanges();
        }
    }
}