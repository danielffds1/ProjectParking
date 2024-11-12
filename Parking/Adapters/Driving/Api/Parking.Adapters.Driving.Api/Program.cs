using Microsoft.EntityFrameworkCore;
using Parking.Adapters.Driven.MongoDB;
using Parking.Adapters.Driven.SQLServer;
using Parking.Adapters.Driven.SQLServer.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServerDependencies(builder.Configuration);

// Registrar dependências do MongoDB
builder.Services.AddMongoDBDependencies(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
