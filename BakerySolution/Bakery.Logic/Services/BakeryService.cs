using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bakery.Data.Entities;
using Bakery.Data.Interfaces;
using Bakery.Logic.Interfaces;


namespace Bakery.Logic.Services
{
    public class BakeryService : IBakeryService
    {
        private readonly IDataRepository _repository;
        private readonly ICatalogFactory _catalogFactory;
        private readonly IStateFactory _stateFactory;
        private readonly IEventFactory _eventFactory;

        public BakeryService(
            IDataRepository repository,
            ICatalogFactory catalogFactory,
            IStateFactory stateFactory,
            IEventFactory eventFactory)
        {
            _repository = repository;
            _catalogFactory = catalogFactory;
            _stateFactory = stateFactory;
            _eventFactory = eventFactory;
        }

        public void AddProduct(string name, string description)
        {
            ICatalog newProduct = _catalogFactory.Create(name, description);
            _repository.AddCatalogItem(newProduct);

            IState newState = _stateFactory.Create($"Product added: {name}");
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

            IEvent saleEvent = _eventFactory.Create("Sale", $"Product {product.Name} sold to {customerName}");
            _repository.AddEvent(saleEvent);

            IState saleState = _stateFactory.Create($"Product {product.Name} sold.");
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
