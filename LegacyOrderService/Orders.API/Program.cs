
using Microsoft.EntityFrameworkCore;
using Orders.Application.Ports;
using Orders.Application.Services;
using Orders.Infrastructure.Data;
using Orders.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// DB folder
var dbFolder = Path.Combine(AppContext.BaseDirectory, "database");
Directory.CreateDirectory(dbFolder);
var dbPath = Path.Combine( builder.Environment.ContentRootPath, "database", "orders.db");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OrdersDbContext>(o =>
    o.UseSqlite($"Data Source={dbPath}"));

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    object value = app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
