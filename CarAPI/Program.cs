using CarAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.UseHttpsRedirection();

app.UseRequestCulture();


app.MapPost("/multiply", async (HttpContext context) =>
{
    Console.WriteLine(context);
    using var reader = new StreamReader(context.Request.Body);
    var body = await reader.ReadToEndAsync();
    Console.WriteLine("testing: Received body: " + body);

    if (!int.TryParse(body, out int number))
    {
        return Results.BadRequest("Invalid number format");
    }
    Console.WriteLine("Received number: " + number);

    return Results.Ok(new { original = number, multiplied = number * 5 });
})
.WithName("MultiplyByFive")
.WithOpenApi();




app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}


public class MultiplyRequest
{
    public int Number { get; set; }
}
