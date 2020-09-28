using System.Collections.Generic;
using System.Threading.Tasks;
using API.Model;

namespace API.Provider
{
    public class ProductDataProvider : IProductDataProvider
    {
        IList<Product> products = new List<Product>() {
            new Product() {
                Name = "basic electricity tariff",
                AnnualCosts = 830M,
                Consumption =3500 },

            new Product() {
                Name = "basic electricity tariff",
                AnnualCosts = 1050M,
                Consumption =4500 },

            new Product() {
                Name = "basic electricity tariff",
                AnnualCosts = 1380M,
                Consumption =6000 },

            new Product() {
                Name = "Packaged tariff",
                AnnualCosts = 800M,
                Consumption =3500   },

            new Product() {
                Name = "Packaged tariff",
                AnnualCosts = 950M,
                Consumption =4500  },

            new Product() {
                Name = "Packaged tariff",
                AnnualCosts = 1400M,
                Consumption =6000 }

        };
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await Task.FromResult(products);
        }
    }
}
