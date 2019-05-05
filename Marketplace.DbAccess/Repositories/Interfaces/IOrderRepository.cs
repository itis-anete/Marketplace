using System.Collections.Generic;
using Marketplace.Core;

namespace Marketplace.DbAccess
{
    public interface IOrderRepository
    {
        void AddNewOrder(Cart cart);

        IEnumerable<Order> GetAllCustomerOrders(string customerLogin);
    }
}