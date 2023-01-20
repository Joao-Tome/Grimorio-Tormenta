using FluentValidation.AspNetCore;
using Grimorio_Tormenta_Back_End.Config.Depencency_Injection;
using GrimorioTormenta.Business.Conversor;
using GrimorioTormenta.Business.Instancia;
using GrimorioTormenta.Intefaces.Conversor;
using GrimorioTormenta.Intefaces.Instancia;
using GrimorioTormenta.Intefaces.Repositorio;
using GrimorioTormenta.Model.Models;
using GrimorioTormenta.Repositorio.Config;
using GrimorioTormenta.Repositorio.Repositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .addDbContextDI(builder.Configuration)
    .addRepositoriosDI()
    .addConversorDi()
    .addValidadoresDI()
    .addInstanciasDI();


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

app.Run();
