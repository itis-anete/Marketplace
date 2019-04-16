using MarketPlace.Core;

namespace MarketPlace.DbAccess
{
    public interface IOrderRepository
    {
        void MakeOrder(Cart cart, Address deliveryAddress = null);
    }
}