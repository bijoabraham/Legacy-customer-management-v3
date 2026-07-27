using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using CustomersWebDemo.DbAccess;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<CustomerEntitiesDbContext>(options =>
    options.UseSqlServer("Server=localhost;Database=Customers;Trusted_Connection=True;TrustServerCertificate=True;"));

var app = builder.Build();
app.MapControllers();
app.Run();
