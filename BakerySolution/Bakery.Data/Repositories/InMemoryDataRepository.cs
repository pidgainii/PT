using Bakery.Data.Contexts;
using Bakery.Data.Entities;
using Bakery.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bakery.Data.Repositories
{
    internal class InMemoryDataRepository : IDataRepository
    {

        private List<ICatalog> _catalog;
        private List<IState> _states;
        public InMemoryDataRepository()
        {
            _catalog = new List<ICatalog>();
            _states = new List<IState>();
        }


        public List<ICatalog> GetCatalog()
        {
            return _catalog;
        }
        public List<IState> GetStates()
        {
            return _states;
        }

        public void AddCatalog(ICatalog catalog)
        {
            _catalog.Add(catalog);
        }
        public void AddState(IState state)
        {
            _states.Add(state);
        }

        public List<ICatalog> GetCatalogByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return new List<ICatalog>();

            return _catalog
                .Where(c => c.Name != null && c.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

    }
}
