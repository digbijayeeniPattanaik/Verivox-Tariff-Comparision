using API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Provider
{
    public interface IProductDataProvider
    {
        Task<IEnumerable<Product>> GetProductsAsync();
    }
}
