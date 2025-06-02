using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Bakery.Logic.Interfaces
{
    public interface IBakeryService
    {
        void BakeProduct(string name, string description);
        void RegisterSale(int id);
        List<ILCatalog> GetAvailableProducts();
        List<ILState> GetAllStates();
    }
}
