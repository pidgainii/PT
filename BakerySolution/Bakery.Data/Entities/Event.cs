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
        public int Id { get; private set; }
        public string Type { get; set; }
        public DateTime Timestamp { get; private set; }
        public string Details { get; set; }

        public Event(string type, string details)
        {
            Type = type;
            Timestamp = DateTime.UtcNow;
            Details = details;
        }

        // Optional constructor for setting ID manually (e.g. from DB)
        public Event(int id, string type, DateTime timestamp, string details)
        {
            Id = id;
            Type = type;
            Timestamp = timestamp;
            Details = details;
        }
    }
}
