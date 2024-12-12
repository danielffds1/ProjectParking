using AutoMapper;
using FluentValidation;
using Parking.Adapters.Driven.MongoDB;
using Parking.Adapters.Driven.SQLServer;
using Parking.Adapters.Driving.Api.Dtos.Vehicle.Request;
using Parking.Adapters.Driving.Api.Mapppings;
using Parking.Core.Application;
using Parking.Core.Domain.Adapters.Driving.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddSqlServerDependencies(builder.Configuration);

// Registrar dependências do MongoDB
builder.Services.AddMongoDBDependencies(builder.Configuration);

// Registrar dependências da aplicação
builder.Services.AddApplicationDependencyModule(builder.Configuration);

//Validadores do endpoint de veículos
builder.Services.AddScoped<IValidator<CreateVehicleRequest>, CreateVehicleValidador>();
builder.Services.AddScoped<IValidator<EntryVehicleRequest>, EntryVehicleValidador>();
builder.Services.AddScoped<IValidator<ExitVehicleRequest>, ExitVehicleValidador>();



//Configurações do AutoMapper
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddScoped<IMapperService, MapperService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
