using API.Controllers;
using API.Dto;
using API.Model;
using API.Provider;
using AutoMapper;
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
        private Mock<IMapper> _mockMapper;

        [TestInitialize]
        public void Init()
        {
            _mockProductDataProvider = new Mock<IProductDataProvider>();
            _mockMapper = new Mock<IMapper>();
            productController = new ProductsController(_mockProductDataProvider.Object, _mockMapper.Object);
        }

        [TestMethod]
        public async Task Test_GetAudit_WhenHasResults_Successful()
        {
            var products = new List<Product>()
            {
                new Product()
                {
                    TariffName = "Packaged tariff",
                    AnnualCosts = 800M,
                    Consumption = 3500
                },
                new Product() {
                TariffName = "basic electricity tariff",
                AnnualCosts = 830M,
                Consumption =3500 }
            };

            var outcome = new Outcome<IEnumerable<Product>>() { Result = products };
            _mockProductDataProvider.Setup(a => a.GetProductsAsync(It.IsAny<int>())).ReturnsAsync(outcome);

            var productDtos = new List<ProductDto>()
            {
                new ProductDto() {
                TariffName = "Packaged tariff",
                AnnualCosts = 800M   },

                new ProductDto() {
                TariffName = "basic electricity tariff",
                AnnualCosts = 830M}
            };

            _mockMapper.Setup(a => a.Map<IReadOnlyList<ProductDto>>(It.IsAny<IEnumerable<Product>>())).Returns(productDtos);
            var result = await productController.GetProducts(It.IsAny<int>());
            _mockProductDataProvider.Verify(a => a.GetProductsAsync(It.IsAny<int>()), Times.Once);
            _mockMapper.Verify(a => a.Map<IReadOnlyList<ProductDto>>(It.IsAny<IEnumerable<Product>>()), Times.Once);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.ActionResult<IReadOnlyList<ProductDto>>));
        }

        [TestMethod]
        public async Task Test_GetAudit_WhenNoResults_Failure()
        {
            _mockProductDataProvider.Setup(a => a.GetProductsAsync(It.IsAny<int>())).ReturnsAsync(new Outcome<IEnumerable<Product>>("Consumption not available"));

            var result = await productController.GetProducts(It.IsAny<int>());

            _mockProductDataProvider.Verify(a => a.GetProductsAsync(It.IsAny<int>()), Times.Once);
            _mockMapper.Verify(a => a.Map<IReadOnlyList<ProductDto>>(It.IsAny<IEnumerable<Product>>()), Times.Never);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.ActionResult<IReadOnlyList<ProductDto>>));
        }
    }
}
