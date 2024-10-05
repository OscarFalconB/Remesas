using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nueva_carpeta.Data;
using Nueva_carpeta.Services;

var builder = WebApplication.CreateBuilder(args);

// Configurar la conexión a PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection") 
    ?? throw new InvalidOperationException("Connection string 'PostgreSQLConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Configuración de Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Registro del servicio HTTP para ConversionService
builder.Services.AddHttpClient<ConversionService>();

// Agregar controladores con vistas
builder.Services.AddControllersWithViews();

// Configuración para el uso de Razor Pages
builder.Services.AddRazorPages(); 

var app = builder.Build();

// Configurar el pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Usar HTTPS y archivos estáticos
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Autenticación y autorización
app.UseAuthentication(); 
app.UseAuthorization();

// Configuración de las rutas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Transaccion}/{action=Crear}/{id?}");  // Ahora apunta al método Crear en Transaccion

app.MapRazorPages();

app.Run();
