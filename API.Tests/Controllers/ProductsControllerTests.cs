using API.Controllers;
using API.Model;
using API.Provider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Tests.Controller
{
    [TestClass]
    public class ProductsControllerTests
    {
        private ProductsController productController;
        private Mock<IProductDataProvider> _mockProductDataProvider;

        [TestInitialize]
        public void Init()
        {
            _mockProductDataProvider = new Mock<IProductDataProvider>();
            productController = new ProductsController(_mockProductDataProvider.Object);
        }

        [TestMethod]
        public async Task Test_GetAudit_WhenHasResults_Successful()
        {
            var products = new List<Product>()
            {
                new Product()
                {
                    TariffName = "Packaged tariff",
                    AnnualCosts = 800M
                },
                new Product() {
                TariffName = "basic electricity tariff",
                AnnualCosts = 830M }
            };

            var outcome = new Outcome<IEnumerable<Product>>() { Result = products };
            _mockProductDataProvider.Setup(a => a.GetProductsAsync(It.IsAny<int>())).ReturnsAsync(outcome);

            var productDtos = new List<Product>()
            {
                new Product() {
                TariffName = "Packaged tariff",
                AnnualCosts = 800M   },

                new Product() {
                TariffName = "basic electricity tariff",
                AnnualCosts = 830M}
            };

            var result = await productController.GetProducts(It.IsAny<int>());
            _mockProductDataProvider.Verify(a => a.GetProductsAsync(It.IsAny<int>()), Times.Once);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.ActionResult<IReadOnlyList<Product>>));
        }

        [TestMethod]
        public async Task Test_GetAudit_WhenNoResults_Failure()
        {
            _mockProductDataProvider.Setup(a => a.GetProductsAsync(It.IsAny<int>())).ReturnsAsync(new Outcome<IEnumerable<Product>>("Consumption not available"));

            var result = await productController.GetProducts(It.IsAny<int>());

            _mockProductDataProvider.Verify(a => a.GetProductsAsync(It.IsAny<int>()), Times.Once);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.ActionResult<IReadOnlyList<Product>>));
        }
    }
}
