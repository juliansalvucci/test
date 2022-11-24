using ContratoTestWebApi.Data;
using ContratoTestWebApi.Models;
using ContratoTestWebApi.Models.Resquest;

namespace ContratoTestWebApi.Services.ContratoServices
{
    public class ContratoService : IContratoService
    {
        public List<Contrato> GetAllContratos(BusquedaRequest br)
        {
            var data = new ContratoRepository();
            var contratos = data.GetAllContratos(br);
            return contratos;
        }

        public List<Contrato> GetContratosPorRazonSocial(BusquedaRequest br)
        {
            var data = new ContratoRepository();
            return data.GetContratosPorRazonSocial(br);
        }

        public List<Contrato> GetContratosPorCuit(BusquedaRequest br)
        {
            var data = new ContratoRepository();
            return data.GetContratosPorCuit(br);
        }

        public int GetCantidadPaginas()
        {
            var data = new ContratoRepository();
            return data.GetCantidadPaginas();
        }

        public int GetCantidadContratosVigentes()
        {
            var data = new ContratoRepository();
            return data.GetCantidadContratosVigentes();
        }

        public int GetCantidadContratosVigentesConDeuda()
        {
            var data = new ContratoRepository();
            return data.GetCantidadContratosVigentesConDeuda();
        }

        public List<Contrato> GetContratosPorUnidadComercial(BusquedaRequest br)
        {
            var data = new ContratoRepository();
            return data.GetContratosPorUnidadComercial(br);
        }
    }
}
