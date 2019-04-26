using Marketplace.Core;

namespace Marketplace.DbAccess
{
    public interface ICartRepository
    {
        void CreateCustomerCart(Customer customer);

        Cart GetCustomerCart(Customer customer);

        void RemoveCart(Cart cartToRemove);
    }
}