using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Presentation.Model.Interfaces
{
    public interface IPState
    {
        int Id { get; }
        string Description { get; set; }
        DateTime UpdatedAt { get; }
        int CatalogId { get; set; }
    }
}
