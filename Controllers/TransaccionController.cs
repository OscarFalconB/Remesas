using Microsoft.AspNetCore.Mvc;
using Nueva_carpeta.Data;
using Nueva_carpeta.Models;
using Nueva_carpeta.Services;
using System.Threading.Tasks;

namespace Nueva_carpeta.Controllers
{
    public class TransaccionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ConversionService _conversionService;

        public TransaccionController(ApplicationDbContext context, ConversionService conversionService)
        {
            _context = context;
            _conversionService = conversionService;
        }

        // GET: Mostrar formulario de creación
        [HttpGet]
        public IActionResult Crear()
        {
            return View();  // Cambié Create a Crear para coincidir con la vista
        }

        // POST: Registrar nueva transacción
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                // Llama al servicio de conversión para obtener la tasa de cambio actual
                var tasaCambio = await _conversionService.ObtenerTasaCambioUsdBtc();

                if (transaccion.Moneda == "USD")
                {
                    // Si la moneda es USD, realiza la conversión a BTC
                    transaccion.MontoFinal = transaccion.MontoEnviado / (decimal)tasaCambio;
                }
                else if (transaccion.Moneda == "BTC")
                {
                    // Si la moneda es BTC, no se hace conversión
                    transaccion.MontoFinal = transaccion.MontoEnviado;
                }

                // Guardar la transacción
                _context.Add(transaccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Listado));
            }
            return View(transaccion);
        }

        // GET: Listado de transacciones
        public IActionResult Listado()
        {
            var transacciones = _context.Transacciones.ToList();
            return View(transacciones);
        }
    }
}
