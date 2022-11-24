using AutoMapper;
using ContratoTestWebApi.Controllers;
using ContratoTestWebApi.Models.Resquest;
using ContratoTestWebApi.Services.ContratoServices;
using ContratoTestWebApi.Services.ExcelServices;

namespace Test
{
    public class ContratoTest
    {
        private readonly ContratoController _contratoController;
        private readonly ContratoService _contratoService;
        private readonly ExcelService _excelService;
        private readonly IMapper _mapper;


        public ContratoTest()
        {
            _excelService = new ExcelService();
            _contratoService = new ContratoService();
            _contratoController = new ContratoController(_contratoService, _excelService,_mapper);
        }

        [Fact]
        public void GetOk()
        {
            var br = new BusquedaRequest
            {
                cantidad = 5,
                page = 0,
                busqueda = "",
                idUnidadComercial = 0
            };

            var result = _contratoController.GetAllContratos(br);

            Assert.NotNull(result);
        }
    }
}