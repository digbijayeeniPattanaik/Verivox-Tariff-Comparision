using API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Provider
{
    public interface IProductDataProvider
    {
        Task<Outcome<IEnumerable<Product>>> GetProductsAsync(int consumption);
    }
}
