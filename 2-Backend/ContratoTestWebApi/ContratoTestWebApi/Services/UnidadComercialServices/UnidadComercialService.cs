using ContratoTestWebApi.Data;
using ContratoTestWebApi.Models;

namespace ContratoTestWebApi.Services.UnidadComercialServices
{
    public class UnidadComercialService : IUnidadComercialService
    {
        public List<UnidadComercial> GetAllUnidadComerciales()
        {
            var data = new UnidadComercialRepository();
            var registros = data.GetAllUnidadesComerciales();
            return registros;
        }
    }
}
