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
    internal class PState: IPState
    {
        public int Id { get; private set; }
        public string Description { get; set; }
        public DateTime UpdatedAt { get; private set; }
        public int CatalogId { get; set; }

        // Constructor desde la entidad de Logic
        public PState(ILState dataState)
        {
            Id = dataState.Id;
            Description = dataState.Description;
            UpdatedAt = dataState.UpdatedAt;
            CatalogId = dataState.CatalogId;
        }

        public PState(int id, string description, int catalogid)
        {
            Id = id;
            Description = description;
            UpdatedAt = DateTime.Now;
            CatalogId = catalogid;
        }
    }
}
