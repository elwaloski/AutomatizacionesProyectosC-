using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using APIQA.Datos;

var builder = WebApplication.CreateBuilder(args);
/*
builder.Services.AddDbContext<APIQAContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("APIQAContext") ?? throw new InvalidOperationException("Connection string 'APIQAContext' not found.")));*/

// Add services to the container.
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

// Añade el logger de Serilog a la configuración de registro
builder.Logging.AddSerilog();

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

