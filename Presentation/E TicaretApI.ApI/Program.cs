using E_TicaretApI.Application.Validations;
using E_TicaretApI.Domain.Entities;
using E_TicaretApI.Persistence;
using E_TicaretApI.Infrastructure;
using FluentValidation;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureService();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IValidator<Product>, ProductValidation>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
