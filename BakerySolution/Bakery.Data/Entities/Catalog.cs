using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bakery.Data.Interfaces;

namespace Bakery.Data.Entities
{
    internal class Catalog : ICatalog
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<IState> States { get; private set; }

        public Catalog(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            States = new List<IState>();
        }
    }
}
