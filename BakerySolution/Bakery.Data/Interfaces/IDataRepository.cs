using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace Bakery.Data.Interfaces
{
    public interface IDataRepository
    {
        List<ICatalog> GetCatalog();
        List<IState> GetStates();

        void AddCatalog(ICatalog catalog);
        void AddState(IState state);

        List<ICatalog> GetCatalogByName(string name);
    }
}