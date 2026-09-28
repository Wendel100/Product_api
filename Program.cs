using Microsoft.EntityFrameworkCore;
using Product_api.Db;
using Product_api.Services;

var builder = WebApplication.CreateBuilder(args);

const string policy = "AllowAll";

// =======================
// Serviços
// =======================

builder.Services.AddControllers();

// Dependency Injection
builder.Services.AddScoped<IProductServices, ProductServices>();

// Entity Framework
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Conexao")
    )
);

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(policy, builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// =======================
// Pipeline HTTP
// =======================

app.UseHttpsRedirection();

app.UseCors(policy);

app.UseAuthorization();

app.MapControllers();

app.Run();