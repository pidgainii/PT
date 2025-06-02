using Bakery.Logic.Interfaces;
using Bakery.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Bakery.Logic.Factories;

namespace Bakery.TestLogic
{
    [TestClass]
    public class BakeryServiceTests
    {
        private IBakeryService _bakeryService;

        [TestInitialize]
        public void Setup()
        {
            var repository = new InMemoryDataRepository();
            _bakeryService = ServiceFactory.Create(repository);
        }

        [TestMethod]
        public void BakeProduct_ShouldAddProductAndState()
        {
            // Arrange
            string productName = "croissant";
            string description = "chocolate";

            // Act
            _bakeryService.BakeProduct(productName, description);

            // Assert
            var products = _bakeryService.GetAvailableProducts();
            Assert.IsTrue(products.Any(p => p.Name == productName));

            var states = _bakeryService.GetAllStates();
            Assert.IsTrue(states.Any(s => s.CatalogId == products.First(p => p.Name == productName).Id &&
                                          s.Description == "baked"));
        }

        [TestMethod]
        public void RegisterSale_ShouldCreateSoldState()
        {
            // Arrange
            string productName = "bread";
            string description = "baguette";

            _bakeryService.BakeProduct(productName, description);
            var product = _bakeryService.GetAvailableProducts().First();

            // Act
            _bakeryService.RegisterSale(product.Id);

            // Assert
            var states = _bakeryService.GetAllStates();
            Assert.IsTrue(states.Any(s => s.CatalogId == product.Id && s.Description == "sold"));
        }

        private void GenerateProductsManually()
        {
            _bakeryService.BakeProduct("bagel", "ny");
            _bakeryService.BakeProduct("muffin", "blueberry");
        }

        private void GenerateProductsBulk(string baseName, int count)
        {
            for (int i = 1; i <= count; i++)
            {
                _bakeryService.BakeProduct($"{baseName} {i}", $"Description {i}");
            }
        }

        [TestMethod]
        public void GenerateProducts_ManualAndBulk_ShouldWork()
        {
            GenerateProductsManually();
            GenerateProductsBulk("donut", 3);

            var products = _bakeryService.GetAvailableProducts();
            Assert.AreEqual(5, products.Count());
        }
    }
}
