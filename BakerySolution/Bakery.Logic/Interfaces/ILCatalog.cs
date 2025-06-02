using System;
using System.Collections.Generic;


namespace Bakery.Logic.Interfaces
{
    public interface ILCatalog
    {
        int Id { get; }
        string Name { get; set; }
        string Description { get; set; }

        List<ILState> States { get; }
    }
}
