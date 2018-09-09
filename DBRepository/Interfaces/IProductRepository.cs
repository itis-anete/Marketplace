using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DBRepository.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();
    }
}
