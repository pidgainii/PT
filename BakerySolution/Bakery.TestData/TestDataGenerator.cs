using Bakery.Data.Contexts;
using Bakery.Data.Interfaces;
using Bakery.Data.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace Bakery.TestData
{
    public static class TestDataGenerator
    {
        // Generate test Users
        public static List<IUser> CreateTestUsers()
        {
            return new List<IUser>
            {
                UserFactory.Create("Alice", "Customer"),
                UserFactory.Create("Bob", "Staff"),
                UserFactory.Create("Charlie", "Supplier")
            };
        }

        // Generate test Catalog items
        public static List<ICatalog> CreateTestCatalogItems()
        {
            return new List<ICatalog>
            {
                CatalogFactory.Create("croissant", "buttery"),
                CatalogFactory.Create("bread", "baguette"),
                CatalogFactory.Create("bread", "garlic")
            };
        }

        // Generate test Events
        public static List<IEvent> CreateTestEvents()
        {
            return new List<IEvent>
            {
                EventFactory.Create("sale", "newsale"),
                EventFactory.Create("baking", "baking"),
                EventFactory.Create("supply", "supply")
            };
        }
    }
}
