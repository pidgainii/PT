using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Data.Interfaces
{
    public interface IUser
    {
        int Id { get; }
        string Name { get; set; }
        string Role { get; set; }

        List<IEvent> Events { get; }
    }
}
