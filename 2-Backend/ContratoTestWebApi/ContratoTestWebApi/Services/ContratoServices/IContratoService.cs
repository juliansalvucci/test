using ContratoTestWebApi.Models;

namespace ContratoTestWebApi.Services.ContratoServices
{
    public interface IContratoService
    {
        public List<Contrato> GetAllContratos(int cant, int pagina, string sort);
        public List<Contrato> GetContratosPorRazonSocial(int cant, int pagina, String sort, string razonSocial);
        public List<Contrato> GetContratosPorCuit(int cant, int pagina, string sort, string cuit);
        public List<Contrato> GetContratosPorUnidadComercial(int cant, int pagina, string sort, int idUnidadComercial);
        public int GetCantidadPaginas();
        public int GetCantidadContratosVigentes();

        public int GetCantidadContratosVigentesConDeuda();

    }
}
