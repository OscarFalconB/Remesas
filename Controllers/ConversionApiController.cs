using Microsoft.AspNetCore.Mvc;
using Parcial_progra.Services;

namespace Parcial_progra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversionApiController : ControllerBase
    {
        private readonly ConversionService _conversionService;

        public ConversionApiController(ConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        [HttpGet("usd-to-btc")]
        public async Task<IActionResult> ObtenerTasaCambioUsdBtc()
        {
            try
            {
                var tasaCambio = await _conversionService.ObtenerTasaCambioUsdBtc();
                return Ok(new { tasaCambio });
            }
            catch
            {
                return StatusCode(500, "Error al obtener la tasa de cambio.");
            }
        }
    }
}
