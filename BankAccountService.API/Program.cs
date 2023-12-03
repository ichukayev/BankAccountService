using BankAccountService.API.Middlewares;
using BankAccountService.Application.Interfaces;
using BankAccountService.Application.Services;
using BankAccountService.Infrastructure.DataAccess;
using BankAccountService.Infrastructure.DataAccess.Repositories;
using BankAccountService.Infrastructure.Services;
using BankAccountService.Infrastructure.MapperProfiles;
using IbanNet.Registry;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
    {
        option.SwaggerDoc("v1", new OpenApiInfo { Title = "Bank Accounts API", Version = "v1" });
    }
);

builder.Services
            .AddEntityFrameworkInMemoryDatabase()
            .AddDbContext<AppDbContext>((sp, options) =>
            {
                options.UseInMemoryDatabase("BankingSystem")
                    .UseInternalServiceProvider(sp);
            });

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(typeof(MapperMarker));

builder.Services.AddScoped<IIbanGenerator, IbanGenerator>();

builder.Services.AddScoped<IIbanGeneratorService, IbanGeneratorService>();

// repositories
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();

//domain services
builder.Services.AddScoped<IAccountService, AccountService>();



var app = builder.Build();

var appDbContext = app.Services.CreateScope().ServiceProvider.GetService<AppDbContext>();
await AppDbContextSeed.SeedAsync(appDbContext);


app.UseMiddleware<ExceptionHandlingMiddleware>();

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
