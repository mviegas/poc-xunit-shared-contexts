var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Use(async (context, next) =>
{
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    logger.LogWarning("Incoming request at {Path}", context.Request.Path);

    await next(context);
});

app.MapGet("/", () => "Hello World!");

app.Run();

public partial class Program
{
}