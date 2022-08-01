using Rappel_API.BLL.Interfaces;
using Rappel_API.BLL.Services;
using Rappel_API.DAL.Interfaces;
using Rappel_API.DAL.Repositories;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add dependancy injection
// - La connection SQL
builder.Services.AddTransient<IDbConnection>(
    service => new SqlConnection(
        builder.Configuration.GetConnectionString("default")
    )
);

// - La DAL
builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();

// - La BLL
builder.Services.AddScoped<IPizzaService, PizzaService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
