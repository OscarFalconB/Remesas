using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemesasApp.Data;
using RemesasApp.Models;
using System.Threading.Tasks;

namespace RemesasApp.Controllers
{
    public class TransaccionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransaccionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Vista para crear una nueva transacción
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        // Procesar la creación de una nueva transacción
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(transaccion);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Listado));
                }
                catch (DbUpdateException ex)
                {
                    // Manejar el error y mostrar un mensaje si es necesario
                    ModelState.AddModelError("", "Ocurrió un error al guardar la transacción.");
                }
            }
            // Si llegamos aquí, es porque hubo un problema con la validación o la base de datos
            return View(transaccion);
        }

        // Listado de transacciones
        public async Task<IActionResult> Listado()
        {
            var transacciones = await _context.Transacciones.ToListAsync(); // Recupera todas las transacciones
            return View(transacciones);
        }
    }
}
