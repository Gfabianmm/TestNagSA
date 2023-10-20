using APIVentas.DataAccess;
using APIVentas.Models;
using APIVentas.Resources.FormaPagoProfile;
using APIVentas.Resources.ProductoProfile;
using APIVentas.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using APIVentas.Resources.FacturaProfile;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(opt => { 
        opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddDbContext<VentasDBContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<ICRUDService<Producto, ProductoQuery, ProductoResource>, ProductoService>();
builder.Services.AddScoped<ICRUDService<FormaPago, FormaPagoQuery, FormaPagoResource>, FormaPagoService>();
builder.Services.AddScoped<ICRUDService<Factura, FacturaQuery, FacturaResource>, FacturaService>();


//builder.Services.AddScoped(typeof(ICRUDService<,,>), typeof(ProductoService));
//builder.Services.AddScoped(typeof(ICRUDService<,,>), typeof(FormaPagoService));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var app = builder.Build();

//TODO: Se aplica la migración de BD
app.MigrateDatabase();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
