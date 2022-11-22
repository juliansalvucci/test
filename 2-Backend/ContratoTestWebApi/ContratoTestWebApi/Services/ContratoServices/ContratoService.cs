using ContratoTestWebApi.Data;
using ContratoTestWebApi.Models;

namespace ContratoTestWebApi.Services.ContratoServices
{
    public class ContratoService : IContratoService
    {
        public List<Contrato> GetAllContratos(int cant, int pagina, string sort)
        {
            var data = new ContratoData();
            var contratos = data.GetAllContratos(cant, pagina, sort);
            return contratos;
        }

        public List<Contrato> GetContratosPorRazonSocial(int cant, int pagina, String sort, string razonSocial)
        {
            var data = new ContratoData();
            return data.GetContratosPorRazonSocial(cant,pagina,sort,razonSocial);
        }

        public List<Contrato> GetContratosPorCuit(int cant, int pagina, string sort, string cuit)
        {
            var data = new ContratoData();
            return data.GetContratosPorCuit(cant, pagina, sort, cuit);
        }

        public int GetCantidadPaginas()
        {
            var data = new ContratoData();
            return data.GetCantidadPaginas();
        }

        public int GetCantidadContratosVigentes()
        {
            var data = new ContratoData();
            return data.GetCantidadContratosVigentes();
        }

        public int GetCantidadContratosVigentesConDeuda()
        {
            var data = new ContratoData();
            return data.GetCantidadContratosVigentesConDeuda();
        }

        public List<Contrato> GetContratosPorUnidadComercial(int cant, int pagina, string sort, int idUnidadComercial)
        {
            var data = new ContratoData();
            return data.GetContratosPorUnidadComercial(cant, pagina, sort, idUnidadComercial);
        }
    }
}
