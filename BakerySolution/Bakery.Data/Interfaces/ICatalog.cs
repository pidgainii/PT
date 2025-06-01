using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Data.Interfaces
{
    public interface ICatalog
    {
        int Id { get; }
        string Name { get; set; }
        string Description { get; set; }

        List<IState> States { get; }
    }
}
