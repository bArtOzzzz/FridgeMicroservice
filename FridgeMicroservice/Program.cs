using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;
using System.Text;
using MassTransit;
using Service;
using Repositories.Abstract;
using Repositories;
using Services.Abstract;
using Services;
using Repositories.Context;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using AuthenticationMicroservice.HealthChecks.DatabaseCheck;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add Fluent Validation
#pragma warning disable CS0618 // Type or member is obsolete
builder.Services.AddFluentValidation(x =>
{
    x.ImplicitlyValidateChildProperties = true;
    x.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
    x.AutomaticValidationEnabled = false;
});
#pragma warning restore CS0618 // Type or member is obsolete

// Add Masstransit && RabbitMQ
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<RabbitMqListener>();
    x.AddBus(provider => Bus.Factory
     .CreateUsingRabbitMq(config =>
    {
        config.Host(new Uri("rabbitmq://localhost"), h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        config.ReceiveEndpoint("product-created-event", ep =>
        {
            ep.UseMessageRetry(r => r.Interval(100, 100));
            ep.ConfigureConsumer<RabbitMqListener>(provider);
        });
    }));
});

// Add services to the container.
builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });

// Enable AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IFridgesRepository, FridgesRepository>();
builder.Services.AddScoped<IFridgesService, FridgesService>();

builder.Services.AddScoped<IModelsRepository, ModelsRepository>();
builder.Services.AddScoped<IModelsService, ModelsService>();

builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IProductsService, ProductsService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Get JWT token from Authentication microservice
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });

// Add connection to the database
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration
           .GetConnectionString("DefaultConnection"), b => b
           .MigrationsAssembly("FridgeMicroservice"));
});

// Add Healthcheck
builder.Services.AddHealthChecks()
                .AddCheck<DatabaseHealthCheck>(nameof(DatabaseHealthCheck))
                .AddCheck<PingHealthCheck>(nameof(PingHealthCheck));

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", config =>
    {
        config.SetIsOriginAllowedToAllowWildcardSubdomains()
              .WithOrigins("http://localhost:5000", "https://localhost:5001")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials()
              .Build();
    });
});

var app = builder.Build();

app.UseCors("AllowSpecificOrigins");

// Healthcheck 
app.MapHealthChecks("/health", new HealthCheckOptions()
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
    AllowCachingResponses = false
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c
       .SwaggerEndpoint("/swagger/v1/swagger.json", "FridgeJWTToken v1"));
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
