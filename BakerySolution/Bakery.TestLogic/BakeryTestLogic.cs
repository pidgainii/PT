using Bakery.Data.Factories;
using Bakery.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bakery.Data.Contexts;


namespace Bakery.TestLogic
{
    /*
    [TestClass]
    public class BakeryServiceTests
    {
        private IBakeryService _bakeryService;

        [TestInitialize]
        public void Setup()
        {
            var context = new DataContext();
            var repository = new InMemoryDataRepository(context);

            _bakeryService = new BakeryService(repository);
        }


        [TestMethod]
        public void AddProduct_ShouldAddProductAndState()
        {
            // Arrange
            string productName = "Chocolate Croissant";
            string description = "Delicious croissant filled with chocolate";

            // Act
            _bakeryService.AddProduct(productName, description);

            // Assert
            var products = _bakeryService.GetAvailableProducts();
            Assert.IsTrue(products.Any(p => p.Name == productName));

            var states = _bakeryService.GetAllStates();
            Assert.IsTrue(states.Any(s => s.Description.Contains(productName)));
        }

        [TestMethod]
        public void RegisterSale_ShouldCreateEventAndState()
        {
            // Arrange
            string productName = "Baguette";
            string description = "Fresh baked baguette";

            _bakeryService.AddProduct(productName, description);
            var product = _bakeryService.GetAvailableProducts().First();

            string customerName = "Alice";

            // Act
            _bakeryService.RegisterSale(product.Id, customerName);

            // Assert
            var events = _bakeryService.GetAllEvents();
            Assert.IsTrue(events.Any(e => e.Type == "Sale" && e.Details.Contains(customerName)));

            var states = _bakeryService.GetAllStates();
            Assert.IsTrue(states.Any(s => s.Description.Contains("sold")));
        }

        // Additional: two ways of generating test data
        private void GenerateProductsManually()
        {
            _bakeryService.AddProduct("Bagel", "Fresh New York bagel");
            _bakeryService.AddProduct("Muffin", "Blueberry muffin");
        }

        private void GenerateProductsBulk(string baseName, int count)
        {
            for (int i = 1; i <= count; i++)
            {
                _bakeryService.AddProduct($"{baseName} {i}", $"Description {i}");
            }
        }

        [TestMethod]
        public void GenerateProducts_ManualAndBulk_ShouldWork()
        {
            // Manual
            GenerateProductsManually();
            // Bulk
            GenerateProductsBulk("Donut", 3);

            var products = _bakeryService.GetAvailableProducts();
            Assert.AreEqual(5, products.Count());
        }
    }
    */

}
