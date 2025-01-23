// it's similar to Express's app creation! WebApplication.CreateBuilder() sets up the foundation for your app
// including: Configuration (appsettings.json, environment variables)
// Logging: Dependency injection container
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

// Registers all your controller endpoints and enables attribute routing
// // This won't work without MapControllers()
// [ApiController]
// [Route("[controller]")]
// public class WeatherController : ControllerBase
app.MapControllers();

// This middleware automatically redirects HTTP requests to HTTPS. 
// For example: Client requests: http://myapi.com/users & Middleware redirects to: https://myapi.com/users
app.UseHttpsRedirection();

// This middleware enables routing to your controllers
// If you don't use them: Anyone can access your endpoints without proving their identity,No role-based access control
// No security for protected endpoints || [Authorize(Roles = "Admin")] // This won't work without auth middleware
app.UseAuthentication(); // Identifies who you are (validates tokens/credentials)
app.UseAuthorization();  // Determines what you can access


var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot",
    "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast") // Gives the route a name (useful for link generation)

    .WithOpenApi(); // Adds OpenAPI/Swagger documentation for this endpoint

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}