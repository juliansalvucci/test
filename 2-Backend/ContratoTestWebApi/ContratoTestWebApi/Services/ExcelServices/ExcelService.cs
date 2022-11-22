using ContratoTestWebApi.Excel;
using ContratoTestWebApi.Models;

namespace ContratoTestWebApi.Services.ExcelServices
{
    public class ExcelService : IExcelService
    {
        public void ExportarAExcel(List<Contrato> contratos)
        {
            var export = new ExcelExporter();
            export.ExportarAExcel(contratos);
        }
    }
}
