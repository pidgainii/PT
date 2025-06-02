using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.TestData
{
    [TestClass]
    public class BakeryDataTests
    {
        [TestMethod]
        public void Test_CreateTestUsers_ShouldReturnThreeUsers()
        {
            var users = TestDataGenerator.CreateTestUsers();
            Assert.AreEqual(3, users.Count);
            Assert.IsTrue(users.Exists(u => u.Name == "Alice"));
        }

        [TestMethod]
        public void Test_CreateTestCatalogItems_ShouldReturnThreeItems()
        {
            var catalogItems = TestDataGenerator.CreateTestCatalogItems();
            Assert.AreEqual(3, catalogItems.Count);
            Assert.IsTrue(catalogItems.Exists(c => c.Name == "croissant"));
        }

        [TestMethod]
        public void Test_CreateTestEvents_ShouldReturnThreeEvents()
        {
            var events = TestDataGenerator.CreateTestEvents();
            Assert.AreEqual(3, events.Count);
            Assert.IsTrue(events.Exists(e => e.Type == "sale"));
        }
    }
}
