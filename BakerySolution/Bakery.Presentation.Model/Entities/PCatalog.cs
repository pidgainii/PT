using Bakery.Data.Interfaces;
using Bakery.Logic.Interfaces;
using Bakery.Presentation.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Presentation.Model.Entities
{
    internal class PCatalog: IPCatalog
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<IPState> States { get; private set; }

        // Constructor desde la entidad de Data
        public PCatalog(ILCatalog dataCatalog)
        {
            Id = dataCatalog.Id;
            Name = dataCatalog.Name;
            Description = dataCatalog.Description;
            States = new List<IPState>();

            foreach (var state in dataCatalog.States)
            {
                States.Add(new PState(state));
            }
        }

        public PCatalog(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            States = new List<IPState>();
        }
    }
}
