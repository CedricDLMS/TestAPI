using Microsoft.EntityFrameworkCore;
using testAPI.IServices;
using testAPI.Middlewares;
using testAPI.Models;
using testAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddScoped<IRandomService, RandomService>();
builder.Services.AddScoped<IRandomService, CryptoRandom>();
builder.Services.AddScoped<IClientService, ClientService>();
//builder.Services.AddDbContext<ExoDbContext>();
builder.Services.AddDbContext<ExoDbContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("ExoDbContextCS"));
});

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

app.UseCustomMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
