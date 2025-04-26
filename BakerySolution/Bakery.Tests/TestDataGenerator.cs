using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bakery.Data.Entities;
using Bakery.Data.Interfaces;


namespace Bakery.Tests
{
    public static class TestDataGenerator
    {
        // Generate test Users
        public static List<IUser> CreateTestUsers()
        {
            return new List<IUser>
            {
                new User("Alice", "Customer"),
                new User("Bob", "Staff"),
                new User("Charlie", "Supplier")
            };
        }

        // Generate test Catalog items
        public static List<ICatalog> CreateTestCatalogItems()
        {
            return new List<ICatalog>
            {
                new Catalog("Croissant", "Buttery French croissant"),
                new Catalog("Sourdough", "Traditional sourdough bread"),
                new Catalog("Baguette", "Classic French baguette")
            };
        }

        // Generate test Events
        public static List<IEvent> CreateTestEvents()
        {
            return new List<IEvent>
            {
                new Event("Sale", "Sold Croissant to Alice"),
                new Event("Delivery", "New stock of Sourdough"),
                new Event("Return", "Baguette returned by customer")
            };
        }
    }
}
