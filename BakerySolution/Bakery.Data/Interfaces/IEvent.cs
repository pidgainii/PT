using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Data.Interfaces
{
    public interface IEvent
    {
        Guid Id { get; }
        string Type { get; set; }
        DateTime Timestamp { get; }
        string Details { get; set; }
    }
}