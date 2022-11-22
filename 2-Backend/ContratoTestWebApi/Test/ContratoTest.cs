using ContratoTestWebApi.Controllers;
using ContratoTestWebApi.Services.ContratoServices;
using ContratoTestWebApi.Services.ExcelServices;

namespace Test
{
    public class ContratoTest
    {
        private readonly ContratoController _contratoController;
        private readonly ContratoService _contratoService;
        private readonly ExcelService _excelService;


        public ContratoTest()
        {
            _excelService = new ExcelService();
            _contratoService = new ContratoService();
            _contratoController = new ContratoController(_contratoService, _excelService);
        }

        [Fact]
        public void GetOk()
        {
            var result = _contratoController.GetAllContratos(5,1,"ASC");

            Assert.NotNull(result);
        }
    }
}