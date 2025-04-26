using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Data.Interfaces
{
    public interface ICatalogFactory
    {
        ICatalog Create(string name, string description);
    }

    public interface IStateFactory
    {
        IState Create(string description);
    }

    public interface IEventFactory
    {
        IEvent Create(string type, string details);
    }
}
