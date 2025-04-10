using Microsoft.EntityFrameworkCore;
using assignment.Infrastructure.Persistence.DBContext;
using assignment.Application.Interface.Gateway;
using assignment.Infrastructure.Repositories;
using assignment.Application.Interface.UseCase;
using assignment.Application.Service;
using assignment.Application.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add Servicess to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddScoped<DbContext, ApplicationDbContext>();

builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
builder.Services.AddScoped<ISalaryRepo, SalaryRepo>();

builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ISalaryService, SalaryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var Servicess = scope.ServiceProvider; // This needs DbContext to work
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();


