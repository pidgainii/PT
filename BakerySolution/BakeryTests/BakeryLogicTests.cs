using BakeryLibrary1.Logic;

namespace BakeryTests
{
    [TestClass]
    public sealed class BakeryLogicTests
    {
        [TestMethod]
        public void BakeBread_WithEnoughIngredients_ReturnsCorrectLoaves()
        {
            var bakery = new Bakery();

            int result = bakery.BakeBread(5, 100); // 5 kg flour, 100g yeast → 5 loaves
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void SellBread_WithSufficientStock_ReturnsRequestedLoaves()
        {
            var bakery = new Bakery();

            int result = bakery.SellBread(10, 7);
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void SellBread_WithInsufficientStock_ReturnsAvailableLoaves()
        {
            var bakery = new Bakery();

            int result = bakery.SellBread(5, 10);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void RestockFlour_AddsFlourCorrectly()
        {
            var bakery = new Bakery();

            int result = bakery.RestockFlour(20, 15);
            Assert.AreEqual(35, result);
        }

        [TestMethod]
        public void PricePerLoaf_WithValidInput_ReturnsCorrectPrice()
        {
            var bakery = new Bakery();

            double result = bakery.PricePerLoaf(100.0, 10);
            Assert.AreEqual(10.0, result);
        }

        [TestMethod]
        public void PricePerLoaf_DivideByZero_ReturnsInfinity()
        {
            var bakery = new Bakery();

            double result = bakery.PricePerLoaf(100.0, 0);
            Assert.AreEqual(double.PositiveInfinity, result);
        }
    }
}
