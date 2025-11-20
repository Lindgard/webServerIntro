var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var visits = 0;

app.MapGet("/", () => "Hello World!");
app.MapGet("/testing", () => {
    visits++;
    if (visits > 10)
    {
        return "sorry, we're full today";
    } else {
    return "This is a test";
    }
});

app.MapGet("/crash", () =>
{
    visits++;
    return Results.InternalServerError();
});

app.MapGet("/visits", () =>
{
    visits++;
    return $"Total requests responded to: {visits}";
});

app.Run();
