using Marketplace.Core;

namespace Marketplace.DbAccess
{
    internal class PgCustomerRepository : PgRepositoryBase, ICustomerRepository
    {
        public PgCustomerRepository(ApplicationContext applicationContext) 
            : base(applicationContext)
        {
        }

        public void CreateCustomer(Customer newCustomer)
        {
            applicationContext.Customers.Add(newCustomer);
            
            var cart = new Cart(newCustomer);
            applicationContext.Carts.Add(cart);

            applicationContext.SaveChanges();
        }

        public void UpdateCustomer(Customer updatedCustomer)
        {
            applicationContext.Customers.Update(updatedCustomer);
            applicationContext.SaveChanges();
        }

        public Customer GetCustomerByLogin(string customerLogin)
        {
            return applicationContext.Customers.Find(customerLogin);
        }
    }
}