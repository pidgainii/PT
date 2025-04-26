using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bakery.Data.Contexts;
using Bakery.Data.Interfaces;

namespace Bakery.Data.Repositories
{
    internal class InMemoryDataRepository : IDataRepository
    {
        private readonly DataContext _context;

        public InMemoryDataRepository(DataContext context)
        {
            _context = context;
        }

        public List<IUser> GetUsers() => _context.Users;
        public Dictionary<Guid, ICatalog> GetCatalog() => _context.Catalog;
        public List<IEvent> GetEvents() => _context.Events;
        public List<IState> GetStates() => _context.States;

        public void AddUser(IUser user) => _context.Users.Add(user);
        public void AddCatalogItem(ICatalog catalogItem) => _context.Catalog[catalogItem.Id] = catalogItem;
        public void AddEvent(IEvent eventItem) => _context.Events.Add(eventItem);
        public void AddState(IState state) => _context.States.Add(state);
    }
}
