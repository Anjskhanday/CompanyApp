using Company.CompanyDbContext;
using Company.Repositories;
using Company.Services;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Batteries.Init();
builder.Services.AddDbContext<CompanyDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductService>();


builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<CategoryService>();

builder.Services.AddScoped<CompanyRepository>();
builder.Services.AddScoped<CompanyService>();

builder.Services.AddScoped<EmployeeRepository>();
builder.Services.AddScoped<EmployeeService>();

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
