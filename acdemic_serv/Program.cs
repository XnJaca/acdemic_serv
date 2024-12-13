using System.Text;
using acdemic_serv.Extensions;
using acdemic_serv.Middleware;
using domain;
using domain.Profiles;

using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.IdentityModel.Tokens;
using Serilog;

using FluentValidation;
using acdemic_serv.Utils;
using static domain.DTO.User.CreateUser;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

//LOCALIZATION
builder.Services.AddLocalization();

// REGISTER MAPPINGS
builder.Services.AddAutoMapper(typeof(MapingProfiles));
 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "server=mysql-139445-0.cloudclusters.net;port=16997;database=acdemic_client;user id=acdemic_db;password=Acdemic2024;";

// Add services to the container.
builder.Services.AddInfraServices(connectionString);
builder.Services.AddApplicationServices();
 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.SupportNonNullableReferenceTypes();
});


// FluentValidation config 
builder.Services.AddValidationServices();
  
//builder.Services.AddHttpContextAccessor();

// Configure Logging
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();

// CONFIGURE AUTHENTICATION
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    }); 
 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

// Configure localization
var supportedCultures = new [] { "es-CR", "en-US" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures [ 0 ])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);

// app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

Log.Information("Server started on {Protocol}://{Host}:{Port}",
    app.Environment.IsDevelopment() ? "http" : "https",
    "localhost",
    app.Environment.IsDevelopment() ? 5000 : 443);

try
{
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
