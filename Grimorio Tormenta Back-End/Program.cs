using FluentValidation.AspNetCore;
using Grimorio_Tormenta_Back_End.Config.Depencency_Injection;
using GrimorioTormenta.Business.Conversor;
using GrimorioTormenta.Business.Instancia;
using GrimorioTormenta.Business.Services;
using GrimorioTormenta.Intefaces.Conversor;
using GrimorioTormenta.Intefaces.Instancia;
using GrimorioTormenta.Intefaces.Repositorio;
using GrimorioTormenta.Model.Models;
using GrimorioTormenta.Repositorio.Config;
using GrimorioTormenta.Repositorio.Repositorio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>(); 
});

builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateAudience = false,
            ValidateIssuer = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.Secret))
        };
    }
);

builder.Services.AddHttpContextAccessor();

builder.Services
    .addDbContextDI(builder.Configuration)
    .addRepositoriosDI()
    .addConversorDi()
    .addValidadoresDI()
    .addInstanciasDI()
    .addServicesDI();

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
