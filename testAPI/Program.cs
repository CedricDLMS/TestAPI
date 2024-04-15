using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using testAPI.IServices;
using testAPI.Middlewares;
using testAPI.Models;
using testAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddScoped<IRandomService, RandomService>();
builder.Services.AddScoped<IRandomService, CryptoRandom>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddMemoryCache();

builder.Services.AddAuthorization();
//builder.Services.AddDbContext<ExoDbContext>();
builder.Services.AddDbContext<ExoDbContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("ExoDbContextCS"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });

        c.OperationFilter<SecurityRequirementsOperationFilter>();
    });

builder.Services.AddIdentityApiEndpoints<AppUser>(c =>
{
    c.Password.RequireUppercase = false;
    c.Password.RequiredLength = 1;
    c.Password.RequireNonAlphanumeric = false;
    c.Password.RequireDigit = false;

})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ExoDbContext>();


var app = builder.Build();

app.MapIdentityApi<AppUser>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseCustomMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
