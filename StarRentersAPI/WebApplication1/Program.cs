using Microsoft.EntityFrameworkCore;
using StarRentersAPI.Data; // Aseg�rate de incluir el espacio de nombres de AppDbContext
using StarRentersAPI.Services; // Si tienes servicios adicionales

var builder = WebApplication.CreateBuilder(args);

// Configurar la conexi�n a la base de datos (usando SQL Server como ejemplo)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar los servicios necesarios para la aplicaci�n
builder.Services.AddScoped<ReviewService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configuraci�n de la tuber�a de solicitudes HTTP
app.UseAuthorization();

app.MapControllers();

app.Run();
