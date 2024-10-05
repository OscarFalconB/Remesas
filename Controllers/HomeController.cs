using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Parcial_progra.Models;

namespace Parcial_progra.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Modificación: Redirigir al método Crear del TransaccionController
        public IActionResult Index()
        {
            return RedirectToAction("Crear", "Transaccion");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
