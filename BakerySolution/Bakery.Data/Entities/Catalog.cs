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
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<IState> States { get; private set; }

        // Constructor without ID, for creating new entries
        public Catalog(string name, string description)
        {
            int timePart = DateTime.UtcNow.Ticks.GetHashCode();
            int randomPart = new Random().Next(1000, 9999);

            Id = (timePart ^ randomPart);
            Name = name;
            Description = description;
            States = new List<IState>();
        }

        internal Catalog(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            States = new List<IState>();
        }

    }
}
