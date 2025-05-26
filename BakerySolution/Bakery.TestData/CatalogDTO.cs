using Bakery.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.TestData
{
    public class CatalogDto : ICatalog
    {
        public Guid Id { get; } = Guid.NewGuid();  // Cambia esto si tu tabla tiene ID tipo Guid
        public string Name { get; set; }
        public string Description { get; set; }

        public List<IState> States => new(); // Aún sin implementar

        public CatalogDto(Catalog c)
        {
            Name = c.Name.Trim();
            Description = c.Description.Trim();
        }
    }
}
