using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bakery.Data.Interfaces;

namespace Bakery.Data.Entities
{
    internal class User : IUser
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public List<IEvent> Events { get; private set; }

        public User(string name, string role)
        {
            Id = Guid.NewGuid();
            Name = name;
            Role = role;
            Events = new List<IEvent>();
        }
    }
}
