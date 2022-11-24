using ContratoTestWebApi.Contexts;
using ContratoTestWebApi.Services.ContratoServices;
using ContratoTestWebApi.Services.ExcelServices;
using ContratoTestWebApi.Services.UnidadComercialServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CONFIGURACIÓN DE CORS
builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

//INYECCIÓN DE DEPENDENCIAS.
builder.Services.AddScoped<IContratoService, ContratoService>();
builder.Services.AddScoped<IExcelService, ExcelService>();
builder.Services.AddScoped<IUnidadComercialService, UnidadComercialService>();
builder.Services.AddAutoMapper(typeof(Program));

//CONFIGURACIÓN DE LA CADENA DE CONEXIÓN Y EF.
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Establecer políticas de cors
app.UseCors("corspolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
