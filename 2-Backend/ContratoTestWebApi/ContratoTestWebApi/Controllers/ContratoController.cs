using ContratoTestWebApi.Models;
using ContratoTestWebApi.Services.ContratoServices;
using ContratoTestWebApi.Services.ExcelServices;
using Microsoft.AspNetCore.Mvc;

namespace ContratoTestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private readonly IContratoService _contratoService;
        private readonly IExcelService _excelService;

        public ContratoController(IContratoService service, IExcelService excelService)
        {
            _contratoService = service;
            _excelService = excelService;
        }



        [HttpGet("/api/GetAllContratos")]
        public ActionResult<List<Contrato>> GetAllContratos(int cant, int pagina, String sort)
        {
            try
            {
                var registros = _contratoService.GetAllContratos(cant,pagina,sort);

               _excelService.ExportarAExcel(registros);

                return Ok(registros);
            }
            catch(Exception ex)
            {
                return BadRequest($"Error de servidor al obtener contratos:{ex.Message}");
            }
        }

        [HttpGet("/api/GetContratosPorUnidadComercial")]
        public ActionResult<List<Contrato>> GetContratosPorUnidadComercial(int cant, int pagina, String sort, int idUnidadComercial)
        {
            try
            {
                var registros = _contratoService.GetContratosPorUnidadComercial(cant, pagina, sort,idUnidadComercial);

                return Ok(registros);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error de servidor al obtener contratos:{ex.Message}");
            }
        }

        [HttpGet("/api/GetCantidadPaginas")]
        public ActionResult<int> GetCantidadPaginas()
        {
            try
            {
                var registros = _contratoService.GetCantidadPaginas();


                return Ok(registros);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error de servidor al obtener contratos:{ex.Message}");
            }
        }

        [HttpGet("/api/GetCantidadContratosVigentes")]
        public ActionResult<int> GetCantidadContratosVigentes()
        {
            try
            {
                var registros = _contratoService.GetCantidadContratosVigentes();

                return Ok(registros);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error de servidor al obtener contratos:{ex.Message}");
            }
        }

        [HttpGet("/api/GetCantidadContratosVigentesConDeuda")]
        public ActionResult<int> GetCantidadContratosVigentesConDeuda()
        {
            try
            {
                var registros = _contratoService.GetCantidadContratosVigentesConDeuda();

                return Ok(registros);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error de servidor al obtener contratos:{ex.Message}");
            }
        }

        
        [HttpGet("/api/GetContratosPorRazonSocial")]
        public ActionResult<List<Contrato>> GetContratosPorRazonSocial(int cant, int pagina, String sort, string razonSocial)
        {
            try
            {
                var registros = _contratoService.GetContratosPorRazonSocial(cant,pagina,sort,razonSocial);
                return Ok(registros);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("/api/GetContratosPorCuit")]
        public ActionResult<List<Contrato>> GetContratosPorCuit(int cant, int pagina, String sort, string cuit)
        {
            try
            {
                var registros = _contratoService.GetContratosPorCuit(cant,pagina,sort,cuit);
                return Ok(registros);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}
