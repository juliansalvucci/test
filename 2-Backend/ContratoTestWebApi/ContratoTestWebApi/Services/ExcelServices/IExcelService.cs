using ContratoTestWebApi.Models;

namespace ContratoTestWebApi.Services.ExcelServices
{
    public interface IExcelService
    {
        public void ExportarAExcel(List<Contrato> contratos);
    }
}
