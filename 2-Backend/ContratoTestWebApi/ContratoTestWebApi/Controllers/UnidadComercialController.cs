using ContratoTestWebApi.Models;
using ContratoTestWebApi.Services.UnidadComercialServices;
using Microsoft.AspNetCore.Mvc;

namespace ContratoTestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadComercialController : ControllerBase
    {
        private readonly IUnidadComercialService _unidadComercialService;

        public UnidadComercialController(IUnidadComercialService unidadComercialService)
        {
            _unidadComercialService = unidadComercialService;
        }

        [HttpGet("/api/GetAllUnidadesComerciales")]
        public ActionResult<List<UnidadComercial>> GetAllUnidadesComerciales()
        {
            try
            {
                var registros = _unidadComercialService.GetAllUnidadComerciales();

                return Ok(registros);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error de servidor al obtener contratos:{ex.Message}");
            }
        }
    }
}
