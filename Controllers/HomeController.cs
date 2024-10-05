using Microsoft.AspNetCore.Mvc;

namespace Nueva_carpeta.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Redirigir a la vista de creación en el controlador Transaccion
            return RedirectToAction("Crear", "Transaccion");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
