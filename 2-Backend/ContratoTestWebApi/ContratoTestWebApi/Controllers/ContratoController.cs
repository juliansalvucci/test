using AutoMapper;
using ContratoTestWebApi.Models;
using ContratoTestWebApi.Models.DTOs;
using ContratoTestWebApi.Models.Resquest;
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
        private readonly IMapper _mapper;

        public ContratoController(IContratoService service, IExcelService excelService, IMapper mapper)
        {
            _contratoService = service;
            _excelService = excelService;
            _mapper = mapper;
        }

        [HttpPost("/api/GetAllContratos")]
        public ActionResult<List<ContratoDto>> GetAllContratos(BusquedaRequest br)
        {
            try
            {
                var registros = _contratoService.GetAllContratos(br);

                var contratosDto = _mapper.Map<List<ContratoDto>>(registros);

                return Ok(contratosDto);
            }
            catch(Exception ex)
            {
                return BadRequest($"Error de servidor al obtener contratos:{ex.Message}");
            }
        }

        [HttpPost("/api/GetContratosPorUnidadComercial")]
        public ActionResult<List<ContratoDto>> GetContratosPorUnidadComercial(BusquedaRequest br)
        {
            try
            {
                var registros = _contratoService.GetContratosPorUnidadComercial(br);

                var contratosDto = _mapper.Map<List<ContratoDto>>(registros);

                return Ok(contratosDto);
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

        
        [HttpPost("/api/GetContratosPorRazonSocial")]
        public ActionResult<List<ContratoDto>> GetContratosPorRazonSocial(BusquedaRequest br)
        {
            try
            {
                var registros = _contratoService.GetContratosPorRazonSocial(br);

                var contratosDto = _mapper.Map<List<ContratoDto>>(registros);

                return Ok(contratosDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("/api/GetContratosPorCuit")]
        public ActionResult<List<ContratoDto>> GetContratosPorCuit(BusquedaRequest br)
        {
            try
            {
                var registros = _contratoService.GetContratosPorCuit(br);

                var contratosDto = _mapper.Map<List<ContratoDto>>(registros);

                return Ok(contratosDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}
