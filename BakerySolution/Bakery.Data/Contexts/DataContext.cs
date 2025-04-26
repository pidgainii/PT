using Bakery.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Data.Contexts
{
    internal class DataContext
    {
        public List<IUser> Users { get; set; } = new();
        public Dictionary<Guid, ICatalog> Catalog { get; set; } = new();
        public List<IEvent> Events { get; set; } = new();
        public List<IState> States { get; set; } = new();
    }
}