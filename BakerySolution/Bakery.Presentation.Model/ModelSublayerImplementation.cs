using Bakery.Logic.Interfaces;
using Bakery.Presentation.Model.Entities;
using Bakery.Presentation.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Presentation.Model
{
    internal class ModelSublayerImplementation: ModelSublayerAPI
    {
        public override List<IPCatalog> GetCatalogs
        {
            get 
            {
                List<IPCatalog> catalogs = new List<IPCatalog>();
                catalogs.Add(new PCatalog(1, "bread", "baguette"));
                catalogs.Add(new PCatalog(2, "pie", "apple"));
                catalogs.Add(new PCatalog(3, "croissant", "buttery"));

                return catalogs;
            }
        }

        public override List<IPState> GetStates
        {
            get
            {
                List<IPState> states = new List<IPState>();
                states.Add(new PState(1, "baked", 1));
                states.Add(new PState(2, "baked", 2));
                states.Add(new PState(3, "sold", 3));

                return states;
            }
        }
    }
}
