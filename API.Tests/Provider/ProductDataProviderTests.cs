using API.Model;
using API.Provider;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Tests.Provider
{
    [TestClass]
    public class ProductDataProviderTests
    {
        private ProductDataProvider productDataProvider;
        private Mock<IMapper> _mockMapper;
        [TestInitialize]
        public void Init()
        {
            _mockMapper = new Mock<IMapper>();
            productDataProvider = new ProductDataProvider(_mockMapper.Object);
        }

        [TestMethod]
        public async Task Test_GetAudit_WhenHasResults_Successful()
        {
            var result = await productDataProvider.GetProductsAsync(3500);

            Assert.IsTrue(result.Successful);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Outcome<IEnumerable<Product>>));
        }

        [TestMethod]
        public async Task Test_GetAudit_WhenNoResults_Failure()
        {
            var expectedList = new List<Product>() {
                new Product() { AnnualCosts = 60, TariffName = "basic electricity tariff" },
                new Product() { AnnualCosts = 800, TariffName = "Packaged tariff" } };
            _mockMapper.Setup(a => a.Map<IEnumerable<Product>>(It.IsAny<IEnumerable<ICalculationUnit>>())).Returns(expectedList);

            var result = await productDataProvider.GetProductsAsync(It.IsAny<int>());

            Assert.IsTrue(result.Successful);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Outcome<IEnumerable<Product>>));
        }
    }
}
