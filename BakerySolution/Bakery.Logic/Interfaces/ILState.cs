using Bakery.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace Bakery.Logic.Interfaces
{
    public interface ILState
    {
        int Id { get; }
        string Description { get; set; }
        DateTime UpdatedAt { get; }
        int CatalogId { get; set; }
    }
}
