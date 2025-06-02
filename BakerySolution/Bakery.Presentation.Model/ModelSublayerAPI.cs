using Bakery.Presentation.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Presentation.Model
{
    public abstract class ModelSublayerAPI
    {
        public abstract List<IPCatalog> GetCatalogs { get; }

        public abstract List<IPState> GetStates { get; }


        public static ModelSublayerAPI Create()
        {
            return new ModelSublayerImplementation();
        }
    }
}
