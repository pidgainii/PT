using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bakery.Data.Interfaces;
using Bakery.Data.Entities;
using Bakery.Data.Factories;

namespace Bakery.TestData
{
    public static class TestDataGenerator
    {
        public static List<IUser> CreateTestUsers()
        {
            return new List<IUser>
            {
                UserFactory.Create("Joe", "baker"),
                UserFactory.Create("Pedro Sanchez", "baker"),
                UserFactory.Create("Alvise", "baker")
            };
        }

        // Generate test Catalog items
        public static List<ICatalog> CreateTestCatalogItems()
        {
            return new List<ICatalog>
            {
                CatalogFactory.Create("Croissant", "Buttery French croissant"),
                CatalogFactory.Create("Sourdough", "Traditional sourdough bread"),
                CatalogFactory.Create("Baguette", "Classic French baguette")
            };
        }

        public static List<IEvent> CreateTestEvents()
        {
            return new List<IEvent>
            {
                EventFactory.Create("Sale", "Sold Croissant to Alice"),
                EventFactory.Create("Delivery", "New stock of Sourdough"),
                EventFactory.Create("Return", "Baguette returned by customer")
            };
        }
    }
}
