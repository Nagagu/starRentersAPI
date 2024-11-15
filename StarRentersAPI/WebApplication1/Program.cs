using Microsoft.EntityFrameworkCore;
using StarRentersAPI.Data; // Asegúrate de incluir el espacio de nombres de AppDbContext
using StarRentersAPI.Services; // Si tienes servicios adicionales

var builder = WebApplication.CreateBuilder(args);

// Configurar la conexión a la base de datos (usando SQL Server como ejemplo)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar los servicios necesarios para la aplicación
builder.Services.AddScoped<ReviewService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configuración de la tubería de solicitudes HTTP
app.UseAuthorization();

app.MapControllers();

app.Run();
