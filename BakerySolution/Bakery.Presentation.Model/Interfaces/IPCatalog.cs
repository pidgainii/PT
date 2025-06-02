using Bakery.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Presentation.Model.Interfaces
{
    public interface IPCatalog
    {
        int Id { get; }
        string Name { get; set; }
        string Description { get; set; }

        List<IPState> States { get; }
    }
}
