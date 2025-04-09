using assignment.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using assignment.Infrastructure.Persistence.DBContext;
using assignment.Application.Service.Persons;
using assignment.Application.Interface.Persons;
using assignment.Infrastructure.Persistence.Seed;
using assignment.Application.Interface.Gateway;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<DummyData>();
builder.Services.AddScoped<ICreate, CreatePerson>();
builder.Services.AddScoped<IListPerson, ListPerson>();
builder.Services.AddScoped<IUpdate, UpdatePerson>();
builder.Services.AddScoped<IDelete, DeletePerson>();
builder.Services.AddScoped<IFilter, FilterPerson>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider; // This needs DbContext to work



    var dummyData = services.GetRequiredService<DummyData>();
    await dummyData.Initialize();
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
