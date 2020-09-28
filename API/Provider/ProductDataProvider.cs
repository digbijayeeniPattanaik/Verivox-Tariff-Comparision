using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Model;

namespace API.Provider
{
    public class ProductDataProvider : IProductDataProvider
    {
        private readonly IList<Product> products = new List<Product>() {
            new Product() {
                TariffName = "basic electricity tariff",
                AnnualCosts = 830M,
                Consumption =3500 },

            new Product() {
                TariffName = "basic electricity tariff",
                AnnualCosts = 1050M,
                Consumption =4500 },

            new Product() {
                TariffName = "basic electricity tariff",
                AnnualCosts = 1380M,
                Consumption =6000 },

            new Product() {
                TariffName = "Packaged tariff",
                AnnualCosts = 800M,
                Consumption =3500   },

            new Product() {
                TariffName = "Packaged tariff",
                AnnualCosts = 950M,
                Consumption =4500  },

            new Product() {
                TariffName = "Packaged tariff",
                AnnualCosts = 1400M,
                Consumption =6000 }

        };
        public async Task<Outcome<IEnumerable<Product>>> GetProductsAsync(int consumption)
        {
            var outcome = new Outcome<IEnumerable<Product>>();
            if (products.Any(a => a.Consumption == consumption))
                outcome.Result = await Task.FromResult(products.Where(a => a.Consumption == consumption).OrderBy(a => a.AnnualCosts).ToList());
            else outcome.ErrorMessage = "Consumption not available";
            return outcome;
        }
    }
}
