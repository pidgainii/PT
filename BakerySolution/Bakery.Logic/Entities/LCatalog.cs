using System;
using System.Collections.Generic;
using Bakery.Logic.Interfaces;
using Bakery.Data.Interfaces;
using Bakery.Data.Entities;

namespace Bakery.Logic.Entities
{
    internal class LCatalog : ILCatalog
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ILState> States { get; private set; }

        // Constructor desde la entidad de Data
        public LCatalog(ICatalog dataCatalog)
        {
            Id = dataCatalog.Id;
            Name = dataCatalog.Name;
            Description = dataCatalog.Description;
            States = new List<ILState>();

            foreach (var state in dataCatalog.States)
            {
                States.Add(new LState(state));
            }
        }

        // Constructor directo para lógica si lo necesitas
        public LCatalog(string name, string description)
        {
            Id = 0; // o genera ID si es necesario
            Name = name;
            Description = description;
            States = new List<ILState>();
        }
    }
}
