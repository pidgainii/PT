using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bakery.Data.Entities;
using Bakery.Data.Factories;
using Bakery.Data.Interfaces;
using Bakery.Logic.Interfaces;
using Bakery.Logic.Entities;
using System.ComponentModel;



namespace Bakery.Logic.Services
{
    internal class BakeryService : IBakeryService
    {
        private readonly IDataRepository _repository;

        public BakeryService(IDataRepository repository)
        {
            _repository = repository;
        }

        public void BakeProduct(string name, string description)
        {
            ICatalog newProduct = CatalogFactory.Create(name, description);
            _repository.AddCatalog(newProduct);

            IState newState = StateFactory.Create("baked", newProduct.Id);
            _repository.AddState(newState);
        }

        public void RegisterSale(int id)
        {
            List<ICatalog> catalog = _repository.GetCatalog();

            ICatalog product = catalog.First(c => c.Id == id);
            if (product == null)
            {
                throw new InvalidOperationException("Product not found.");
            }

            IState state = StateFactory.Create("sold", id);
            _repository.AddState(state);
        }

        public List<ILCatalog> GetAvailableProducts()
        {
            List<ICatalog> catalogs = _repository.GetCatalog();
            List<ILCatalog> lista = new List<ILCatalog>();
            foreach (ICatalog catalog in catalogs)
            {
                lista.Add(new LCatalog(catalog));
            }
            return lista;
        }

        public List<ILState> GetAllStates()
        {
            List<IState> states = _repository.GetStates();
            List<ILState> lista = new List<ILState>();
            foreach (IState state in states)
            {
                lista.Add(new LState(state));
            }
            return lista;
        }
    }
}

