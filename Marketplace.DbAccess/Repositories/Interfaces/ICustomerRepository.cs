using Marketplace.Core;

namespace Marketplace.DbAccess
{
    public interface ICustomerRepository
    {
        void CreateCustomer(Customer newCustomer);

        void UpdateCustomer(Customer updatedCustomer);

        Customer GetCustomerByLogin(string customerLogin);
    }
}