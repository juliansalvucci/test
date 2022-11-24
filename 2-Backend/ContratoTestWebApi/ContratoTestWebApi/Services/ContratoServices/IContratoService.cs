using ContratoTestWebApi.Models;
using ContratoTestWebApi.Models.Resquest;

namespace ContratoTestWebApi.Services.ContratoServices
{
    public interface IContratoService
    {
        public List<Contrato> GetAllContratos(BusquedaRequest br);
        public List<Contrato> GetContratosPorRazonSocial(BusquedaRequest br);
        public List<Contrato> GetContratosPorCuit(BusquedaRequest br);
        public List<Contrato> GetContratosPorUnidadComercial(BusquedaRequest br);
        public int GetCantidadPaginas();
        public int GetCantidadContratosVigentes();

        public int GetCantidadContratosVigentesConDeuda();

    }
}
