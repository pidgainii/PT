using System;
using System.Collections.Generic;
using Bakery.Logic.Interfaces;
using Bakery.Data.Interfaces;
using Bakery.Data.Entities;

namespace Bakery.Logic.Entities
{
    internal class LState : ILState
    {
        public int Id { get; private set; }
        public string Description { get; set; }
        public DateTime UpdatedAt { get; private set; }
        public List<IEvent> Events { get; private set; }
        public int CatalogId { get; set; }

        // Constructor desde la entidad de Data
        public LState(IState dataState)
        {
            Id = dataState.Id;
            Description = dataState.Description;
            UpdatedAt = dataState.UpdatedAt;
            CatalogId = dataState.CatalogId;
            Events = new List<IEvent>(dataState.Events); // copia directa, si son interfaces compartidas
        }

        // Constructor directo para lógica si lo necesitas
        public LState(string description, int catalogId)
        {
            Id = 0; // o genera ID si es necesario
            Description = description;
            UpdatedAt = DateTime.UtcNow;
            CatalogId = catalogId;
            Events = new List<IEvent>();
        }
    }
}
