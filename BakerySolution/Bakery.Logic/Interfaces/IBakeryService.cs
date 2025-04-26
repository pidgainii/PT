using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bakery.Data.Interfaces;

namespace Bakery.Logic.Interfaces
{
    public interface IBakeryService
    {
        void AddProduct(string name, string description);
        void RegisterSale(Guid productId, string customerName);
        IEnumerable<ICatalog> GetAvailableProducts();
        IEnumerable<IEvent> GetAllEvents();
        IEnumerable<IState> GetAllStates();
    }
}
