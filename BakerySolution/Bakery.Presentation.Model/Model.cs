using Bakery.Data.Interfaces;
using Bakery.Presentation.Model.Interfaces;
using Bakery.Logic.Interfaces;
using System.Collections.Generic;
using Bakery.Presentation.Model.Entities;


namespace Bakery.Presentation.Model
{
    internal class Model: ModelSublayerAPI
    {
        private readonly IBakeryService _bakeryService;

        public Model(IBakeryService bakeryService)
        {
            _bakeryService = bakeryService;
        }

        //we transform the data from logic to our own types
        public override List<IPCatalog> GetCatalogs
        {
            get
            {
                List<ILCatalog> listalogic = _bakeryService.GetAvailableProducts();
                List<IPCatalog> lista = new List<IPCatalog>();
                foreach (var catalog in listalogic)
                {
                    lista.Add(new PCatalog(catalog));
                }

                return lista;
            }
        }

        public override List<IPState> GetStates
        {
            get
            {
                List<ILState> listalogic = _bakeryService.GetAllStates();
                List<IPState> lista = new List<IPState>();
                foreach (var catalog in listalogic)
                {
                    lista.Add(new PState(catalog));
                }

                return lista;
            }
        }
    }
}
