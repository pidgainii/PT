using CalculatorLibrary.Logic;

namespace CalculatorLibrary.Tests
{
    [TestClass]
    public sealed class CalculatorLogicTests
    {
        [TestMethod]
        public void Add_TwoNumbers_ReturnsCorrectSum()
        {
            var calculator = new Calculator();

            int result = calculator.Add(3, 7);
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Sub_TwoNumbers_ReturnsCorrectSub()
        {
            var calculator = new Calculator();

            int result = calculator.Sub(3, 7);
            Assert.AreEqual(-4, result);
        }

        [TestMethod]
        public void Mul_TwoNumbers_ReturnsCorrectMul()
        {
            var calculator = new Calculator();

            int result = calculator.Mul(3, 7);
            Assert.AreEqual(21, result);
        }

        [TestMethod]
        public void Div_TwoNumbers_ReturnsCorrectQuo()
        {
            var calculator = new Calculator();

            double result = calculator.Div(12, 4);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Div_TwoNumbers_ReturnsInfinity()
        {
            var calculator = new Calculator();

            double result = calculator.Div(12, 0);
            Assert.AreEqual(double.PositiveInfinity, result);
        }
    }
}
