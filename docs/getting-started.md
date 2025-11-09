# Getting Started with FlutterSharp

This guide will help you create your first FlutterSharp application in C#.

## Prerequisites

- .NET 9.0 SDK or later
- Basic knowledge of C# and .NET
- A code editor (Visual Studio, VS Code, or Rider)

## Installation

### Option 1: Clone the Repository

```bash
git clone https://github.com/yourusername/FlutterSharp.git
cd FlutterSharp
```

### Option 2: Add as Project Reference

Add FlutterSharp to your existing solution:

```bash
dotnet sln add path/to/FlutterSharp.Core/FlutterSharp.Core.csproj
```

## Your First FlutterSharp Application

### 1. Create a Console Application

```bash
dotnet new console -n MyFirstApp
cd MyFirstApp
dotnet add reference ../FlutterSharp/src/FlutterSharp.Core/FlutterSharp.Core.csproj
```

### 2. Write the Code

Edit `Program.cs`:

```csharp
using FlutterSharp.Core.Controls;
using FlutterSharp.Core.Controls.Core;
using FlutterSharp.Core.Controls.Material;

// Create a page
var page = new Page
{
    Title = "My First FlutterSharp App",
    Theme = "light"
};

// Create a layout
var column = new Column
{
    HorizontalAlignment = "center",
    VerticalAlignment = "center"
};

// Add a text control
var text = new Text("Hello, FlutterSharp!")
{
    Size = 32,
    Weight = "bold",
    Color = "blue"
};

column.AddChild(text);
page.AddChild(column);

// Serialize to JSON
var json = System.Text.Json.JsonSerializer.Serialize(page, new System.Text.Json.JsonSerializerOptions
{
    WriteIndented = true
});

Console.WriteLine(json);
```

### 3. Run the Application

```bash
dotnet run
```

You should see JSON output representing your FlutterSharp page.

## Building an Interactive Counter

Let's build a more interactive application with event handling:

```csharp
using FlutterSharp.Core.Controls;
using FlutterSharp.Core.Controls.Core;
using FlutterSharp.Core.Controls.Material;

var page = new Page
{
    Title = "Counter App",
    Theme = "light"
};

var column = new Column
{
    HorizontalAlignment = "center",
    VerticalAlignment = "center",
    Spacing = 10
};

// Title
var title = new Text("Counter App")
{
    Size = 32,
    Weight = "bold"
};

// Counter display
var counter = new Text("0")
{
    Size = 48,
    Color = "blue"
};

// Counter state
int count = 0;

// Increment button
var incrementButton = new ElevatedButton("Increment");
incrementButton.Click += (sender, e) =>
{
    count++;
    counter.Value = count.ToString();
    Console.WriteLine($"Count: {count}");
};

// Decrement button
var decrementButton = new ElevatedButton("Decrement");
decrementButton.Click += (sender, e) =>
{
    count--;
    counter.Value = count.ToString();
    Console.WriteLine($"Count: {count}");
};

// Reset button
var resetButton = new OutlinedButton("Reset");
resetButton.Click += (sender, e) =>
{
    count = 0;
    counter.Value = "0";
    Console.WriteLine("Counter reset");
};

// Build the UI tree
column.AddChild(title);
column.AddChild(counter);
column.AddChild(incrementButton);
column.AddChild(decrementButton);
column.AddChild(resetButton);

page.AddChild(column);

// For demonstration, trigger some events
incrementButton.OnClick();
incrementButton.OnClick();
decrementButton.OnClick();
```

## Creating a Web Application

To create a web application with ASP.NET Core:

### 1. Create ASP.NET Core Project

```bash
dotnet new web -n MyWebApp
cd MyWebApp
dotnet add reference ../FlutterSharp/src/FlutterSharp.Web/FlutterSharp.Web.csproj
```

### 2. Configure Program.cs

```csharp
using FlutterSharp.Core.Controls;
using FlutterSharp.Core.Controls.Core;
using FlutterSharp.Core.Controls.Material;
using FlutterSharp.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add FlutterSharp services
builder.Services.AddFlutterSharp(page =>
{
    page.Title = "My Web App";
    page.Theme = "light";

    var column = new Column
    {
        HorizontalAlignment = "center",
        VerticalAlignment = "center"
    };

    var text = new Text("Welcome to FlutterSharp Web!")
    {
        Size = 28,
        Weight = "bold"
    };

    var button = new ElevatedButton("Click Me");
    button.Click += (sender, e) =>
    {
        text.Value = "Button clicked!";
    };

    column.AddChild(text);
    column.AddChild(button);
    page.AddChild(column);
});

var app = builder.Build();

// Enable FlutterSharp WebSocket middleware
app.UseFlutterSharp();

// Optional: Serve a landing page
app.MapGet("/", () => Results.Content(@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <title>FlutterSharp Web App</title>
</head>
<body>
    <h1>FlutterSharp Web Server</h1>
    <p>WebSocket endpoint: <code>ws://localhost:5000/ws</code></p>
    <p>Connect a Flutter/Flet client to this endpoint.</p>
</body>
</html>
", "text/html"));

app.Run();
```

### 3. Run the Web Application

```bash
dotnet run
```

Navigate to `http://localhost:5000` in your browser.

## Understanding FlutterSharp Concepts

### Controls

Controls are the building blocks of your UI. FlutterSharp provides:

- **Layout Controls**: Column, Row, Stack, Container
- **Material Controls**: ElevatedButton, OutlinedButton, TextField, Checkbox
- **Cupertino Controls**: CupertinoButton, CupertinoSwitch, CupertinoSlider
- **Display Controls**: Text, Image, Icon

### Page

The Page is the root container for your application:

```csharp
var page = new Page
{
    Title = "My App",
    Theme = "light"  // or "dark"
};
```

### Layout

Use Column and Row for vertical and horizontal layouts:

```csharp
// Vertical layout
var column = new Column
{
    HorizontalAlignment = "center",
    VerticalAlignment = "start",
    Spacing = 10
};

// Horizontal layout
var row = new Row
{
    HorizontalAlignment = "start",
    VerticalAlignment = "center",
    Spacing = 5
};
```

### Event Handling

Most controls support events:

```csharp
var button = new ElevatedButton("Click");
button.Click += (sender, e) =>
{
    Console.WriteLine("Button clicked!");
};

var textField = new TextField { Label = "Name" };
textField.Change += (sender, e) =>
{
    Console.WriteLine($"Text changed: {textField.Value}");
};
```

### Reactive Updates

When you change control properties, the UI automatically updates:

```csharp
var text = new Text("Initial");
var button = new ElevatedButton("Update");

button.Click += (sender, e) =>
{
    text.Value = "Updated!";  // UI updates automatically
};
```

## Common Controls Guide

### Text Display

```csharp
var text = new Text("Hello, World!")
{
    Size = 24,
    Weight = "bold",
    Color = "blue",
    TextAlign = "center"
};
```

### Buttons

```csharp
// Elevated (filled) button
var elevated = new ElevatedButton("Submit")
{
    Disabled = false
};

// Outlined button
var outlined = new OutlinedButton("Cancel");

// Text button
var textButton = new TextButton("Learn More");

// Icon button
var iconButton = new IconButton
{
    Icon = "favorite",
    IconColor = "red"
};
```

### Text Input

```csharp
var textField = new TextField
{
    Label = "Enter your name",
    Hint = "John Doe",
    Value = "",
    Autofocus = true,
    Password = false,
    Multiline = false
};

textField.Change += (sender, e) =>
{
    Console.WriteLine($"Value: {textField.Value}");
};
```

### Checkboxes and Switches

```csharp
var checkbox = new Checkbox
{
    Label = "I agree to terms",
    Value = false
};

checkbox.Change += (sender, e) =>
{
    Console.WriteLine($"Checked: {checkbox.Value}");
};

var toggle = new Switch
{
    Label = "Enable notifications",
    Value = true
};
```

### Sliders

```csharp
var slider = new Slider
{
    Min = 0,
    Max = 100,
    Value = 50,
    Divisions = 10,
    Label = "Volume"
};

slider.Change += (sender, e) =>
{
    Console.WriteLine($"Volume: {slider.Value}");
};
```

### Dropdowns

```csharp
var dropdown = new Dropdown
{
    Label = "Select country",
    Value = "US"
};

dropdown.AddChild(new Option { Key = "US", Text = "United States" });
dropdown.AddChild(new Option { Key = "UK", Text = "United Kingdom" });
dropdown.AddChild(new Option { Key = "CA", Text = "Canada" });

dropdown.Change += (sender, e) =>
{
    Console.WriteLine($"Selected: {dropdown.Value}");
};
```

## Layouts and Containers

### Column (Vertical)

```csharp
var column = new Column
{
    HorizontalAlignment = "center",  // start, center, end, stretch
    VerticalAlignment = "start",      // start, center, end, stretch
    Spacing = 10
};

column.AddChild(new Text("Item 1"));
column.AddChild(new Text("Item 2"));
column.AddChild(new Text("Item 3"));
```

### Row (Horizontal)

```csharp
var row = new Row
{
    HorizontalAlignment = "space-between",
    VerticalAlignment = "center",
    Spacing = 5
};

row.AddChild(new IconButton { Icon = "home" });
row.AddChild(new Text("Home"));
row.AddChild(new IconButton { Icon = "settings" });
```

### Container

```csharp
var container = new Container
{
    Width = 200,
    Height = 100,
    Padding = "10",
    Margin = "5",
    BgColor = "lightblue",
    BorderRadius = 8
};

container.AddChild(new Text("Boxed content"));
```

### Stack (Layered)

```csharp
var stack = new Stack();

// Background
stack.AddChild(new Container { Width = 300, Height = 200, BgColor = "gray" });

// Foreground text
stack.AddChild(new Text("Overlay text") { Color = "white" });
```

## Building Complex UIs

### Form Example

```csharp
var page = new Page { Title = "Contact Form" };

var column = new Column { Spacing = 15 };

// Name field
var nameField = new TextField
{
    Label = "Name",
    Autofocus = true
};

// Email field
var emailField = new TextField
{
    Label = "Email",
    KeyboardType = "email"
};

// Message field
var messageField = new TextField
{
    Label = "Message",
    Multiline = true,
    MaxLines = 5
};

// Subscribe checkbox
var subscribeCheckbox = new Checkbox
{
    Label = "Subscribe to newsletter",
    Value = true
};

// Submit button
var submitButton = new ElevatedButton("Submit");
submitButton.Click += (sender, e) =>
{
    Console.WriteLine($"Name: {nameField.Value}");
    Console.WriteLine($"Email: {emailField.Value}");
    Console.WriteLine($"Message: {messageField.Value}");
    Console.WriteLine($"Subscribe: {subscribeCheckbox.Value}");
};

column.AddChild(new Text("Contact Us") { Size = 28, Weight = "bold" });
column.AddChild(nameField);
column.AddChild(emailField);
column.AddChild(messageField);
column.AddChild(subscribeCheckbox);
column.AddChild(submitButton);

page.AddChild(column);
```

### Navigation Example

```csharp
var page = new Page { Title = "Navigation Demo" };

var tabs = new NavigationBar { SelectedIndex = 0 };

tabs.AddChild(new NavigationBarDestination
{
    Icon = "home",
    Label = "Home"
});

tabs.AddChild(new NavigationBarDestination
{
    Icon = "search",
    Label = "Search"
});

tabs.AddChild(new NavigationBarDestination
{
    Icon = "person",
    Label = "Profile"
});

var content = new Text("Home Content") { Size = 24 };

tabs.Change += (sender, e) =>
{
    content.Value = tabs.SelectedIndex switch
    {
        0 => "Home Content",
        1 => "Search Content",
        2 => "Profile Content",
        _ => "Unknown"
    };
};

var column = new Column();
column.AddChild(content);
column.AddChild(tabs);

page.AddChild(column);
```

## Testing Your Application

### Unit Tests

```csharp
using Xunit;
using FlutterSharp.Core.Controls.Material;

public class ButtonTests
{
    [Fact]
    public void Button_ClickEvent_Fires()
    {
        var button = new ElevatedButton("Test");
        int clickCount = 0;

        button.Click += (sender, e) => clickCount++;

        button.OnClick();

        Assert.Equal(1, clickCount);
    }

    [Fact]
    public void Button_Disabled_NoEvent()
    {
        var button = new ElevatedButton("Test") { Disabled = true };
        int clickCount = 0;

        button.Click += (sender, e) => clickCount++;

        button.OnClick();

        Assert.Equal(0, clickCount);
    }
}
```

## Next Steps

1. **Explore Sample Applications**
   - Check out the [samples](../samples) directory for complete examples
   - Try the HelloWorld and WebApp samples

2. **Read Control Documentation**
   - See [Control Reference](control-reference.md) for detailed documentation
   - Browse the [FlutterSharp.Core README](../src/FlutterSharp.Core/README.md)

3. **Build Your Own App**
   - Start with a simple counter or form
   - Add navigation and multiple pages
   - Integrate with databases and APIs

4. **Join the Community**
   - Report issues on GitHub
   - Contribute to the project
   - Share your applications

## Troubleshooting

### Common Issues

**Issue: Controls not showing up**
- Ensure controls are added to page: `page.AddChild(control)`
- Check control visibility properties
- Verify parent layout constraints

**Issue: Events not firing**
- Check event handler is registered: `button.Click += handler`
- Ensure control is not disabled
- Verify event trigger method is called

**Issue: Build errors**
```bash
# Restore and rebuild
dotnet clean
dotnet restore
dotnet build
```

**Issue: WebSocket connection fails**
- Ensure server is running
- Check WebSocket URL format: `ws://` or `wss://`
- Verify firewall allows connections

## Resources

- [FlutterSharp GitHub Repository](https://github.com/yourusername/FlutterSharp)
- [FlutterSharp.Web Documentation](../src/FlutterSharp.Web/README.md)
- [Sample Applications](../samples)
- [.NET Documentation](https://docs.microsoft.com/dotnet)
- [Flet Framework](https://flet.dev) (inspiration for FlutterSharp)

## Getting Help

If you're stuck:

1. Check this guide and other documentation
2. Search existing GitHub issues
3. Create a new issue with:
   - Code sample
   - Expected vs actual behavior
   - Error messages
   - Environment info (.NET version, OS)

Happy coding with FlutterSharp!
