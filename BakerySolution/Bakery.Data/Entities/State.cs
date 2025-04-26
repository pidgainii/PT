using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bakery.Data.Interfaces;

namespace Bakery.Data.Entities
{
    public class State : IState
    {
        public Guid Id { get; private set; }
        public string Description { get; set; }
        public DateTime UpdatedAt { get; private set; }
        public List<IEvent> Events { get; private set; }

        public State(string description)
        {
            Id = Guid.NewGuid();
            Description = description;
            UpdatedAt = DateTime.UtcNow;
            Events = new List<IEvent>();
        }
    }
}
