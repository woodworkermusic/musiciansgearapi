using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.EntityFrameworkCore;
using MusiciansGearRegistry.Api.Core.interfaces;
using MusiciansGearRegistry.Api.Core.services;
using MusiciansGearRegistry.Api.ExceptionHandling;
using MusiciansGearRegistry.Api.Logging.interfaces;
using MusiciansGearRegistry.Api.Logging.Services;
using MusiciansGearRegistry.Api.Security.interfaces;
using MusiciansGearRegistry.Api.Security.Models;
using MusiciansGearRegistry.Api.Security.services;
using MusiciansGearRegistry.Data.infrastructure;
using MusiciansGearRegistry.Data.Models;
using MusiciansGearRegistry.Data.repositories;

var builder = WebApplication.CreateBuilder(args);

var aiOptions = new ApplicationInsightsServiceOptions() { ConnectionString = builder.Configuration["ApplicationInsights:ConnectionString"] };

builder.Services.AddApplicationInsightsTelemetry(aiOptions);

// Add services to the container.
builder.Services.AddScoped(typeof(IGearImageService), typeof (GearImageService));
builder.Services.AddScoped(typeof(IManufacturerService), typeof(ManufacturerService));
builder.Services.AddScoped(typeof(IGearModelService), typeof(GearModelService));
builder.Services.AddScoped(typeof(IGearTypeService), typeof(GearTypeService));
builder.Services.AddScoped(typeof(IUserProfileService), typeof(UserProfileService));
builder.Services.AddScoped(typeof(IUserGearService), typeof(UserGearService));

// repositories:
builder.Services.AddScoped(typeof(IGearImageRepository), typeof(GearImageRepository));
builder.Services.AddScoped(typeof(IManufacturerRepository), typeof(ManufacturerRepository));
builder.Services.AddScoped(typeof(IGearModelRepository), typeof(GearModelRepository));
builder.Services.AddScoped(typeof(IGearTypeRepository), typeof(GearTypeRepository));
builder.Services.AddScoped(typeof(IUserGearRepository), typeof(UserGearRepository));
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
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options => {
    options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    options.IgnoreObsoleteActions();
    options.IgnoreObsoleteProperties();
    options.CustomSchemaIds(type => type.FullName);
});

string[] allowedOrigins = ["*"];

builder.Services.AddCors(options =>
{
    options.AddPolicy("MusiciansGearRegistryApi", builder =>
        builder
            .WithOrigins(allowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddOptions();
builder.Services.AddLogging();

//builder.Services.AddProblemDetails();

var app = builder.Build();

//app.UseExceptionHandler(e => e.Run(async context => await Results.Problem().ExecuteAsync(context)));
//app.UseMiddleware<GlobalExceptionHandler>();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("MusiciansGearRegistryApi");
app.UseAuthorization();

app.UseEndpoints(e => e.MapControllers());
//app.MapControllers();
app.Run();
