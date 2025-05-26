using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bakery.Data.Entities;
using Bakery.Data.Factories;
using Bakery.Data.Interfaces;
using Bakery.Logic.Interfaces;


namespace Bakery.Logic.Services
{
    public class BakeryService : IBakeryService
    {
        private readonly IDataRepository _repository;

        public BakeryService(
            IDataRepository repository)
        {
            _repository = repository;
        }

        public void AddProduct(string name, string description)
        {
            ICatalog newProduct = CatalogFactory.Create(name, description);
            _repository.AddCatalogItem(newProduct);

            IState newState = StateFactory.Create($"Product added: {name}");
            _repository.AddState(newState);
        }

        public void RegisterSale(Guid productId, string customerName)
        {
            var catalog = _repository.GetCatalog();
            if (!catalog.ContainsKey(productId))
            {
                throw new InvalidOperationException("Product not found.");
            }

            var product = catalog[productId];

            IEvent saleEvent = EventFactory.Create("Sale", $"Product {product.Name} sold to {customerName}");
            _repository.AddEvent(saleEvent);

            IState saleState = StateFactory.Create($"Product {product.Name} sold.");
            _repository.AddState(saleState);
        }

        public IEnumerable<ICatalog> GetAvailableProducts()
        {
            return _repository.GetCatalog().Values;
        }

        public IEnumerable<IEvent> GetAllEvents()
        {
            return _repository.GetEvents();
        }

        public IEnumerable<IState> GetAllStates()
        {
            return _repository.GetStates();
        }
    }
}
