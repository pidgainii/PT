using Bakery.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.TestData
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void TestFetchCatalog()
        {
            IDataRepository repo = new SqlDataRepository();
            var catalog = repo.GetCatalog();

            Assert.IsNotNull(catalog);
            Assert.IsTrue(catalog.Count > 0, "No se encontraron ítems en el catálogo");

            foreach (var item in catalog.Values)
            {
                Console.WriteLine($"Catalog: {item.Name} - {item.Description}");
            }
        }
    }

}
