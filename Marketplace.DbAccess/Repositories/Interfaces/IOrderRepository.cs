using System.Collections.Generic;
using Marketplace.Core;

namespace Marketplace.DbAccess
{
    public interface IOrderRepository
    {
        void MakeOrder(Cart cart, Address deliveryAddress = null);

        IEnumerable<Order> GetAllCustomerOrders(Customer customer);
    }
}