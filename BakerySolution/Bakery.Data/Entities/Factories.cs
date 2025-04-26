using Bakery.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Data.Entities
{
    internal class CatalogFactory : ICatalogFactory
    {
        public ICatalog Create(string name, string description)
        {
            return new Catalog(name, description);
        }
    }

    internal class StateFactory : IStateFactory
    {
        public IState Create(string description)
        {
            return new State(description);
        }
    }

    internal class EventFactory : IEventFactory
    {
        public IEvent Create(string type, string details)
        {
            return new Event(type, details);
        }
    }
}
