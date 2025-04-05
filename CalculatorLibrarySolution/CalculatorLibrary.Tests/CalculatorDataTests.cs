using CalculatorLibrary.Data;

namespace CalculatorLibrary.Tests
{
    [TestClass()]
    public class ILinq2SQLTests
    {
        [TestMethod()]
        public void CreateLinq2SQLTest()
        {
            DataLayerAbstract linq2SQL = DataLayerAbstract.CreateLinq2SQL();
            Assert.IsNotNull(linq2SQL);
            Assert.ThrowsException<NotImplementedException>(() => linq2SQL.Connect());
        }
    }
}
