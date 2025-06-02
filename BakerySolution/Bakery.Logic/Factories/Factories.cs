using Bakery.Data.Interfaces;
using Bakery.Logic.Interfaces;
using Bakery.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Logic.Factories
{
    public static class ServiceFactory
    {
        public static IBakeryService Create(IDataRepository repository)
        {
            return new BakeryService(repository);
        }
    }
}
