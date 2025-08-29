using Microsoft.EntityFrameworkCore;
using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Api.Core.services;
using MusiciansGearRegistry.Api.Core.Services;
using MusiciansGearRegistry.Api.Logging.interfaces;
using MusiciansGearRegistry.Api.Logging.Services;
using MusiciansGearRegistry.Api.Security.interfaces;
using MusiciansGearRegistry.Api.Security.Models;
using MusiciansGearRegistry.Api.Security.services;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;
using MusiciansGearRegistry.Data.repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped(typeof(IEquipmentImageService), typeof (EquipmentImageService));
builder.Services.AddScoped(typeof(IEquipmentManufacturerService), typeof(EquipmentManufacturerService));
builder.Services.AddScoped(typeof(IEquipmentModelService), typeof(EquipmentModelService));
builder.Services.AddScoped(typeof(IEquipmentTypeService), typeof(EquipmentTypeService));
builder.Services.AddScoped(typeof(IUserProfileService), typeof(UserProfileService));
builder.Services.AddScoped(typeof(IUserEquipmentService), typeof(UserEquipmentService));

// repositories:
builder.Services.AddScoped(typeof(IEquipmentImageRepository), typeof(EquipmentImageRepository));
builder.Services.AddScoped(typeof(IEquipmentManufacturerRepository), typeof(EquipmentManufacturerRepository));
builder.Services.AddScoped(typeof(IEquipmentModelRepository), typeof(EquipmentModelRepository));
builder.Services.AddScoped(typeof(IEquipmentTypeRepository), typeof(EquipmentTypeRepository));
builder.Services.AddScoped(typeof(IUserEquipmentRepository), typeof(UserEquipmentRepository));
builder.Services.AddScoped(typeof(IUserProfileRepository), typeof(UserProfileRepository));

// security / logging
builder.Services.AddScoped(typeof(ILoggingService), typeof(NLogLogger));
builder.Services.AddScoped(typeof(ILoginService), typeof(LoginService));
builder.Services.AddScoped(typeof(ITokenHandlerService), typeof(TokenHandlerService));
//builder.Services.AddScoped(typeof(IWebSecurity));

// dbContext:
var connectionString = builder.Configuration.GetConnectionString("MusiciansGearDb");

builder.Services.AddDbContext<MusiciansGearRegistryContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<SecurityContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
