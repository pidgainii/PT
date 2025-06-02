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
    internal class DataRepository: IDataRepository
    {
        private readonly DataClasses1DataContext _context;


        public DataRepository(DataClasses1DataContext context)
        {
            _context = context;
        }

        public List<ICatalog> GetCatalog()
        {
            List<Bakery.Data.Contexts.Catalog> dbCatalogs = _context.Catalog.ToList(); // Load from DataContext

            List<ICatalog> result = dbCatalogs.Select(c => new Entities.Catalog(c.Id, c.Name, c.Description))
                                   .Cast<ICatalog>()
                                   .ToList();

            return result;
        }
        public List<IState> GetStates()
        {
            List<Bakery.Data.Contexts.State> dbStates = _context.State.ToList(); // LINQ-to-SQL State

            List<IState> result = dbStates
                .Select(s => new Entities.State(s.Id, s.Description, s.UpdatedAt, s.CatalogId))
                .Cast<IState>()
                .ToList();

            return result;
        }

        public void AddCatalog(ICatalog catalog)
        {
            List<ICatalog> list = new List<ICatalog>();
            list.Add(catalog);

            _context.AddCatalogs(list);
        }
        public void AddState(IState state)
        {
            List<IState> list = new List<IState>();
            list.Add(state);

            _context.AddStates(list);
        }

        public List<ICatalog> GetCatalogByName(string name)
        {
            var dbCatalogs = _context.FilterCatalogByName_ForEach(name).ToList();

            var result = dbCatalogs.Select(c => new Entities.Catalog(c.Id, c.Name, c.Description))
                                   .Cast<ICatalog>()
                                   .ToList();

            return result;
        }
    }
}
