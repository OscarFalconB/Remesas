using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nueva_carpeta.Models;  // Asegúrate de tener este using

namespace Nueva_carpeta.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Transaccion> Transacciones { get; set; }  // Asegúrate de que el DbSet esté configurado correctamente
    }
}
