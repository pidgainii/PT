using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bakery.Data.Interfaces;
using Bakery.Data.Factories;
using System.Diagnostics;

namespace Bakery.Data.Contexts
{
    public partial class DataClasses1DataContext: System.Data.Linq.DataContext
    {
        public void AddCatalogs(IEnumerable<ICatalog> catalogs)
        {
            foreach (ICatalog catalog in catalogs)
            {
                Catalog c = new Catalog()
                {
                    Id = catalog.Id,
                    Name = catalog.Name,
                    Description = catalog.Description
                };
                this.Catalog.InsertOnSubmit(c);
            }

            this.SubmitChanges();
        }

        public void AddStates(IEnumerable<IState> states)
        {
            foreach (IState state in states)
            {
                State s = new State()
                {
                    Id = state.Id,
                    Description = state.Description,
                    CatalogId = state.CatalogId,
                    UpdatedAt = state.UpdatedAt
                };
                this.State.InsertOnSubmit(s);
            }

            this.SubmitChanges();
        }



        public IEnumerable<Catalog> FilterCatalogByName_ForEach(string name)
        {
            List<Catalog> _result = new List<Catalog>();
            foreach (Catalog _row in this.Catalog)
                if (_row.Name.Equals(name))
                    _result.Add(_row);
            return _result;
        }

        // QUERY SYNTAX
        public IEnumerable<Catalog> FilterCatalogByName_QuerySyntax(string name)
        {
            return from _catalog in this.Catalog
                   where _catalog.Name.Equals(name)
                   select _catalog;
        }

        // METHOD SYNTAX
        public IEnumerable<Catalog> FilterCatalogByName_MethodSyntax(string name)
        {
            return this.Catalog.Where(_person => _person.Name.Equals(name));
        }



        public void TruncateAllData()
        {
            // Delete from child tables first to avoid FK conflicts
            this.ExecuteCommand("DELETE FROM State");
            this.ExecuteCommand("DELETE FROM Catalog");
            this.SubmitChanges();
        }
    }
}
