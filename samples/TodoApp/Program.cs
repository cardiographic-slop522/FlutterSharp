using FlutterSharp.Core.Controls;
using FlutterSharp.Core.Controls.Core;
using FlutterSharp.Core.Controls.Material;
using FlutterSharp.Web.Extensions;
using TodoApp;

var builder = WebApplication.CreateBuilder(args);

// Add FlutterSharp services
builder.Services.AddFlutterSharp(page =>
{
    page.Title = "FlutterSharp Todo App";
    page.Theme = "light";

    // Main container
    var mainContainer = new Container
    {
        Padding = "20"
    };

    var mainColumn = new Column
    {
        HorizontalAlignment = "center",
        Spacing = 20
    };

    // Title
    var title = new Text("Simple Todo List")
    {
        Size = 32,
        Weight = "bold",
        Color = "#2196f3"
    };

    // Description
    var description = new Text("A simplified todo app demonstrating FlutterSharp basics")
    {
        Size = 14,
        Color = "#666"
    };

    // Input section
    var inputRow = new Row
    {
        Spacing = 10,
        HorizontalAlignment = "center"
    };

    var todoInput = new TextField
    {
        Label = "What needs to be done?",
        Width = 400,
        Autofocus = true
    };

    var addButton = new ElevatedButton("Add Todo")
    {
        BackgroundColor = "#2196f3",
        Color = "white"
    };

    // Todo items display (we'll show them as simple text for now)
    var todoListColumn = new Column
    {
        Spacing = 10,
        Width = 600
    };

    // Sample initial todos (static for this simplified version)
    var todo1Container = new Container
    {
        Padding = "10",
        BackgroundColor = "#f5f5f5",
        BorderRadius = 4,
        Margin = "0,0,0,5"
    };
    var todo1Row = new Row
    {
        HorizontalAlignment = "space-between"
    };
    var todo1Text = new Text("Learn FlutterSharp")
    {
        Size = 16
    };
    var todo1DeleteBtn = new IconButton
    {
        Icon = "delete",
        IconColor = "#f44336"
    };
    todo1Row.AddChild(todo1Text);
    todo1Row.AddChild(todo1DeleteBtn);
    todo1Container.AddChild(todo1Row);

    var todo2Container = new Container
    {
        Padding = "10",
        BackgroundColor = "#f5f5f5",
        BorderRadius = 4,
        Margin = "0,0,0,5"
    };
    var todo2Row = new Row
    {
        HorizontalAlignment = "space-between"
    };
    var todo2Text = new Text("Build an awesome app")
    {
        Size = 16
    };
    var todo2DeleteBtn = new IconButton
    {
        Icon = "delete",
        IconColor = "#f44336"
    };
    todo2Row.AddChild(todo2Text);
    todo2Row.AddChild(todo2DeleteBtn);
    todo2Container.AddChild(todo2Row);

    var todo3Container = new Container
    {
        Padding = "10",
        BackgroundColor = "#f5f5f5",
        BorderRadius = 4,
        Margin = "0,0,0,5"
    };
    var todo3Row = new Row
    {
        HorizontalAlignment = "space-between"
    };
    var todo3Text = new Text("Deploy to production")
    {
        Size = 16
    };
    var todo3DeleteBtn = new IconButton
    {
        Icon = "delete",
        IconColor = "#f44336"
    };
    todo3Row.AddChild(todo3Text);
    todo3Row.AddChild(todo3DeleteBtn);
    todo3Container.AddChild(todo3Row);

    // Add click handlers (simplified - just log for demonstration)
    addButton.Click += (sender, e) =>
    {
        Console.WriteLine($"Add button clicked - Input value: {todoInput.Value}");
    };

    todo1DeleteBtn.Click += (sender, e) =>
    {
        Console.WriteLine("Delete todo 1");
    };

    todo2DeleteBtn.Click += (sender, e) =>
    {
        Console.WriteLine("Delete todo 2");
    };

    todo3DeleteBtn.Click += (sender, e) =>
    {
        Console.WriteLine("Delete todo 3");
    };

    // Build input row
    inputRow.AddChild(todoInput);
    inputRow.AddChild(addButton);

    // Build todo list
    todoListColumn.AddChild(todo1Container);
    todoListColumn.AddChild(todo2Container);
    todoListColumn.AddChild(todo3Container);

    // Stats
    var statsText = new Text("3 items total")
    {
        Size = 14,
        Color = "#666"
    };

    // Instructions
    var instructionsContainer = new Container
    {
        Padding = "15",
        BackgroundColor = "#e3f2fd",
        BorderRadius = 8,
        Margin = "20,0,0,0"
    };
    var instructionsText = new Text("Note: This is a simplified version showing static todos. Dynamic add/remove functionality requires additional core library features.")
    {
        Size = 12,
        Color = "#1976d2"
    };
    instructionsContainer.AddChild(instructionsText);

    // Build main layout
    mainColumn.AddChild(title);
    mainColumn.AddChild(description);
    mainColumn.AddChild(inputRow);
    mainColumn.AddChild(todoListColumn);
    mainColumn.AddChild(statsText);
    mainColumn.AddChild(instructionsContainer);

    mainContainer.AddChild(mainColumn);
    page.AddChild(mainContainer);
});

var app = builder.Build();

// Enable FlutterSharp WebSocket middleware
app.UseFlutterSharp();

// Serve landing page
app.MapGet("/", () => Results.Content(@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <title>FlutterSharp Todo App</title>
    <style>
        body {
            font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, sans-serif;
            max-width: 800px;
            margin: 50px auto;
            padding: 20px;
            background: #f5f5f5;
        }
        .container {
            background: white;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
        }
        h1 { color: #2196F3; margin-top: 0; }
        code {
            background: #f4f4f4;
            padding: 2px 6px;
            border-radius: 3px;
            font-family: 'Courier New', monospace;
        }
        .info { background: #e3f2fd; padding: 15px; border-radius: 4px; margin: 15px 0; }
        ul { line-height: 1.8; }
    </style>
</head>
<body>
    <div class='container'>
        <h1>📝 FlutterSharp Todo App</h1>
        <div class='info'>
            <strong>WebSocket endpoint:</strong> <code>ws://localhost:5000/ws</code>
        </div>

        <h2>Features (Simplified Version)</h2>
        <ul>
            <li>✅ Todo item display</li>
            <li>✅ Text input for new todos</li>
            <li>✅ Delete button UI</li>
            <li>✅ Event logging to console</li>
            <li>📋 Static todo list (demonstrates layout)</li>
        </ul>

        <h2>Technology Stack</h2>
        <ul>
            <li><strong>Backend:</strong> ASP.NET Core 9.0 + FlutterSharp.Web</li>
            <li><strong>UI Framework:</strong> Flutter Material Design controls via C#</li>
            <li><strong>Communication:</strong> WebSocket + MessagePack</li>
            <li><strong>Architecture:</strong> Event-driven</li>
        </ul>

        <h2>Note</h2>
        <p>This is a simplified static version of the todo app. Full dynamic functionality (adding/removing items) would require additional features like:</p>
        <ul>
            <li>Children collection manipulation (Clear, Add, Remove)</li>
            <li>State synchronization between server and client</li>
            <li>Form submission events</li>
        </ul>
    </div>
</body>
</html>
", "text/html"));

app.Run();
