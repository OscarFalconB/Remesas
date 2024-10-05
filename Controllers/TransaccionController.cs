using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial_progra.Data;
using Parcial_progra.Models;
using Parcial_progra.Services;

namespace Parcial_progra.Controllers
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

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                if (transaccion.Moneda == "USD")
                {
                    var tasaCambio = await _conversionService.ObtenerTasaCambioUsdBtc();
                    transaccion.TasaCambio = tasaCambio;
                    transaccion.MontoFinal = transaccion.MontoEnviado / tasaCambio;
                }

                _context.Add(transaccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Listado));
            }
            return View(transaccion);
        }

        public async Task<IActionResult> Listado()
        {
            var transacciones = await _context.Transacciones.ToListAsync();
            return View(transacciones);
        }
    }
}
