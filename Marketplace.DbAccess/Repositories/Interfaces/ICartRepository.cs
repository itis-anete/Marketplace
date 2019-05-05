using Marketplace.Core;

namespace Marketplace.DbAccess
{
    public interface ICartRepository
    {
        Cart GetCustomerCart(string customerLogin);

        void UpdateCart(Cart updatedCart);
    }
}