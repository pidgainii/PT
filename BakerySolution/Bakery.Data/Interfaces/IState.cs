using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Data.Interfaces
{
    public interface IState
    {
        Guid Id { get; }
        string Description { get; set; }
        DateTime UpdatedAt { get; }

        List<IEvent> Events { get; }
    }
}
