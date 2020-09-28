using API.Model;
using API.Provider;
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

        [TestInitialize]
        public void Init()
        {
            productDataProvider = new ProductDataProvider();
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
            var result = await productDataProvider.GetProductsAsync(It.IsAny<int>());

            Assert.IsFalse(result.Successful);
            Assert.AreEqual(result.ErrorMessage, "Consumption not available");
            Assert.IsNull(result.Result);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Outcome<IEnumerable<Product>>));
        }
    }
}
