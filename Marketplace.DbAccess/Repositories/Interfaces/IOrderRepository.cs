using System.Collections.Generic;
using Marketplace.Core;

namespace Marketplace.DbAccess
{
    public interface IOrderRepository
    {
        void MakeOrder(Cart cart);

        IEnumerable<Order> GetAllCustomerOrders(Customer customer);
    }
}