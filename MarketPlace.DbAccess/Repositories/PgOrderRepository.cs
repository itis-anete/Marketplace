using System.Linq;
using MarketPlace.Core;

namespace MarketPlace.DbAccess
{
    internal class PgOrderRepository : PgRepositoryBase, IOrderRepository
    {
        public PgOrderRepository(ApplicationContext applicationContext)
            : base(applicationContext)
        {
        }

        public void MakeOrder(Cart cart, Address deliveryAddress = null)
        {
            var products = cart.ProductInfos
                .Select(productInfo => productInfo.Product);
            
            var newOrder = new Order(
                cart.Customer, 
                products, 
                cart.TotalInUsDollarsWithDiscounts,
                deliveryAddress);

            applicationContext.Orders.Add(newOrder);
            applicationContext.SaveChanges();
        }
    }
}