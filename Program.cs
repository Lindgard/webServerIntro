var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var visits = 0;

var messages = new List<Message>();

//* Accept new create message requests and
//* figures out what to do with them.
app.MapPost("/message", (MessageCreateInfo createInfo) =>
{
    Console.WriteLine($"New Message from: {createInfo.Alias}. Content: {createInfo.Content}");

    var newMessage = new Message(createInfo);
    messages.Add(newMessage);

    return "Message accepted";
});

//* Returns a list of the message we have received.
app.MapGet("/message", () =>
{
    return messages;
});

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

