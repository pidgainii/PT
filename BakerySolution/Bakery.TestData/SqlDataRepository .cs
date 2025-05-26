using Bakery.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.TestData
{
    public class SqlDataRepository : IDataRepository
    {
        private readonly DataClasses1DataContext _context;

        public SqlDataRepository()
        {
            // Usa el connection string del App.config de Bakery.TestData
            var connStr = System.Configuration.ConfigurationManager.ConnectionStrings["BakeryDb"].ConnectionString;
            _context = new DataClasses1DataContext(connStr);
        }

        public Dictionary<Guid, ICatalog> GetCatalog()
        {
            return _context.Catalog.ToDictionary(
                c => Guid.NewGuid(), // cambia esto si tienes un campo real de tipo Guid
                c => new CatalogDto(c) as ICatalog
            );
        }

        public List<IUser> GetUsers() => new();  // aún sin implementación
        public List<IEvent> GetEvents() => new();
        public List<IState> GetStates() => new();

        public void AddUser(IUser user) => throw new NotImplementedException();
        public void AddCatalogItem(ICatalog catalogItem) => throw new NotImplementedException();
        public void AddEvent(IEvent eventItem) => throw new NotImplementedException();
        public void AddState(IState state) => throw new NotImplementedException();
    }
}