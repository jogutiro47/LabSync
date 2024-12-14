using LabSync.Backend.Data;
using LabSync.Backend.Repositories.Implementations;
using LabSync.Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Evitar la redundancia ciclica en la respuesta de los JSON
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("ConnectionLocalMariaDB"),
    //options.UseMySql(builder.Configuration.GetConnectionString("ConnectionRedMovaiMariaDB"),
    new MySqlServerVersion(new Version(11, 5, 2)))); // Ajusta la versión según tu MariaDB

builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();
builder.Services.AddScoped<IPacientesRepository, PacientesRepository>();
builder.Services.AddScoped<IEPSaludsRepository, EPSaludsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

app.Run();