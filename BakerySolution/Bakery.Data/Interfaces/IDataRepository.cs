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
        List<IUser> GetUsers();
        Dictionary<Guid, ICatalog> GetCatalog();
        List<IEvent> GetEvents();
        List<IState> GetStates();

        void AddUser(IUser user);
        void AddCatalogItem(ICatalog catalogItem);
        void AddEvent(IEvent eventItem);
        void AddState(IState state);
    }
}