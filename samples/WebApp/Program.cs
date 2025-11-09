using FlutterSharp.Core.Controls;
using FlutterSharp.Core.Controls.Core;
using FlutterSharp.Core.Controls.Material;
using FlutterSharp.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add FlutterSharp services
builder.Services.AddFlutterSharp(page =>
{
    page.Title = "FlutterSharp Counter Demo";
    page.Theme = "light";

    // Build the UI
    var column = new Column
    {
        HorizontalAlignment = "center",
        VerticalAlignment = "center"
    };

    var title = new Text("FlutterSharp Counter")
    {
        Size = 32,
        Weight = "bold"
    };

    var counter = new Text("0")
    {
        Size = 48,
        Color = "blue"
    };

    int count = 0;
    var button = new ElevatedButton("Increment");
    button.Click += (sender, e) =>
    {
        count++;
        counter.Value = count.ToString();
    };

    column.AddChild(title);
    column.AddChild(counter);
    column.AddChild(button);

    page.AddChild(column);
});

var app = builder.Build();

// Enable FlutterSharp WebSocket middleware
app.UseFlutterSharp();

// Serve a simple HTML page for testing
app.MapGet("/", () => Results.Content(@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <title>FlutterSharp Demo</title>
</head>
<body>
    <h1>FlutterSharp Web Server</h1>
    <p>WebSocket endpoint available at: <code>ws://localhost:5000/ws</code></p>
    <p>Connect a Flutter client to this endpoint to see the FlutterSharp UI.</p>
    <h2>Quick Test</h2>
    <pre>
// Connect with JavaScript WebSocket:
const ws = new WebSocket('ws://localhost:5000/ws');
ws.onopen = () => console.log('Connected to FlutterSharp');
ws.onmessage = (event) => console.log('Received:', event.data);
    </pre>
</body>
</html>
", "text/html"));

app.Run();
