using System;
using System.Collections.Generic;
using Bakery.Data.Interfaces;

namespace Bakery.Data.Entities
{
    internal class User : IUser
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public List<IEvent> Events { get; private set; }

        public User(string name, string role)
        {
            Name = name;
            Role = role;
            Events = new List<IEvent>();
        }

        public User(int id, string name, string role)
        {
            Id = id;
            Name = name;
            Role = role;
            Events = new List<IEvent>();
        }
    }
}
