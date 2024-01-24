using Basket.API.Mappers;
using Basket.API.Repositories;
using Basket.API.Repositories.Interfaces;
using MassTransit;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Basket.API", Version = "v1" });
});

//MassTrasint configuration
var configuration = builder.Configuration;
var server = configuration.GetSection("EventBusSettings")["Server"] ?? string.Empty;
var user = configuration.GetSection("EventBusSettings")["User"] ?? string.Empty;
var password = configuration.GetSection("EventBusSettings")["Password"] ?? string.Empty;

builder.Services.AddMassTransit((x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(server, "/", h =>
        {
            h.Username(user);
            h.Password(password);
        });

        cfg.ConfigureEndpoints(context);
    });
}));

// General configuration
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddAutoMapper(typeof(BasketProfile));

// Redis cnfiguration
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = configuration.GetSection("CacheSettings")["ConnectionString"];
});

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
