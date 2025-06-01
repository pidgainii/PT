using Bakery.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bakery.Data.Entities;

namespace Bakery.Data.Factories
{
    public static class UserFactory
    {
        public static IUser Create(string name, string role)
        {
            return new User(name, role);
        }
    }
    public static class CatalogFactory
    {
        public static ICatalog Create(string name, string description)
        {
            return new Catalog(name, description);
        }
    }

    public static class StateFactory
    {
        public static IState Create(string description, int catalogId)
        {
            return new State(description, catalogId);
        }
    }

    public static class EventFactory
    {
        public static IEvent Create(string type, string details)
        {
            return new Event(type, details);
        }
    }
}
