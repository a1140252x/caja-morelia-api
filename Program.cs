using Data;
using Infrastructure.Repositories;
using Domain.Interfaces;
using Application.Services;
using Microsoft.EntityFrameworkCore;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Configuración de Entity Framework Core para usar SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inyección de dependencias
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<CrearClienteService>();
builder.Services.AddScoped<ActualizarClienteService>();
builder.Services.AddScoped<ObtenerClientesService>();
builder.Services.AddScoped<ObtenerClientePorIdService>();
builder.Services.AddScoped<EliminarClienteService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.UseMiddleware<ApiKeyMiddleware>();
app.MapControllers();
app.Run();
