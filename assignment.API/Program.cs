using assignment.Infrastructure.Gateway;
using assignment.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using assignment.Infrastructure.Persistence;
using assignment.Application.Task;
using assignment.Application.Interface.Task;
using assignment.Application.UseCase.Task;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ICreate, CreateTask>();
builder.Services.AddScoped<IAddBulk, BulkAddTasks>();
builder.Services.AddScoped<IDelete, DeleteTask>();
builder.Services.AddScoped<IEdit, EditTask>();
builder.Services.AddScoped<IGetById, GetTask>();
builder.Services.AddScoped<IGetAll, ListAllTasks>();
builder.Services.AddScoped<IDeleteBulk, BulkDeleteTasks>();

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
