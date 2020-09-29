using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Model;
using API.Products;
using AutoMapper;

namespace API.Provider
{
    public class ProductDataProvider : IProductDataProvider
    {
        public ProductDataProvider(IMapper mapper)
        {
            this.mapper = mapper;
        }

        private readonly IMapper mapper;

        public async Task<Outcome<IEnumerable<Product>>> GetProductsAsync(int consumption)
        {
            var outcome = new Outcome<IEnumerable<Product>>();
            IEnumerable<ICalculationUnit> units = GetCalculationUnitsForAllProducts(consumption);

            outcome.Result = await Task.FromResult(mapper.Map<IEnumerable<Product>>(units));
            return outcome;
        }

        private IEnumerable<ICalculationUnit> GetCalculationUnitsForAllProducts(int consumption)
        {
            List<ICalculationUnit> units = new List<ICalculationUnit>();
            units.Add(new ProductA(consumption));
            units.Add(new ProductB(consumption));
            units = units.OrderBy(a => a.AnnualCosts).ToList();
            return units;
        }
    }
}
