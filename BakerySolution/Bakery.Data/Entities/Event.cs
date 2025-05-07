using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bakery.Data.Interfaces;

namespace Bakery.Data.Entities
{
    internal class Event : IEvent
    {
        public Guid Id { get; private set; }
        public string Type { get; set; }
        public DateTime Timestamp { get; private set; }
        public string Details { get; set; }

        public Event(string type, string details)
        {
            Id = Guid.NewGuid();
            Type = type;
            Timestamp = DateTime.UtcNow;
            Details = details;
        }
    }
}
