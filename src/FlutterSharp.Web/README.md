# FlutterSharp.Web

ASP.NET Core integration for FlutterSharp, enabling you to build Flutter applications with C# backend using WebSocket communication.

## Overview

FlutterSharp.Web provides seamless integration between FlutterSharp and ASP.NET Core, allowing you to:

- Host FlutterSharp applications in ASP.NET Core web servers
- Handle WebSocket connections for real-time Flutter client communication
- Use dependency injection for application configuration
- Leverage ASP.NET Core middleware pipeline
- Build reactive UIs with C# event handlers

## Installation

Add the FlutterSharp.Web package to your ASP.NET Core project:

```bash
dotnet add package FlutterSharp.Web
```

Or add it to your `.csproj` file:

```xml
<ItemGroup>
  <ProjectReference Include="path/to/FlutterSharp.Web/FlutterSharp.Web.csproj" />
</ItemGroup>
```

## Quick Start

### 1. Create an ASP.NET Core Application

```bash
dotnet new web -n MyFlutterSharpApp
cd MyFlutterSharpApp
dotnet add reference path/to/FlutterSharp.Web/FlutterSharp.Web.csproj
```

### 2. Configure FlutterSharp in Program.cs

```csharp
using FlutterSharp.Core.Controls;
using FlutterSharp.Core.Controls.Core;
using FlutterSharp.Core.Controls.Material;
using FlutterSharp.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add FlutterSharp services
builder.Services.AddFlutterSharp(page =>
{
    page.Title = "My FlutterSharp App";
    page.Theme = "light";

    // Build your UI
    var column = new Column
    {
        HorizontalAlignment = "center",
        VerticalAlignment = "center"
    };

    var text = new Text("Hello from FlutterSharp!")
    {
        Size = 24,
        Weight = "bold"
    };

    column.AddChild(text);
    page.AddChild(column);
});

var app = builder.Build();

// Enable FlutterSharp WebSocket middleware
app.UseFlutterSharp();

app.Run();
```

### 3. Run the Application

```bash
dotnet run
```

The WebSocket endpoint will be available at `ws://localhost:5000/ws`.

## Architecture

```
┌─────────────────────┐
│  Flutter Client     │
│  (Web/Desktop/Mobile)│
└──────────┬──────────┘
           │ WebSocket
           │ MessagePack
           ▼
┌─────────────────────┐
│  ASP.NET Core       │
│  + FlutterSharp.Web │
├─────────────────────┤
│  Middleware         │
│  - WebSocket Handler│
│  - Session Manager  │
├─────────────────────┤
│  FlutterSharp.Core  │
│  - Controls         │
│  - Protocol         │
└─────────────────────┘
```

## API Reference

### Service Extensions

#### AddFlutterSharp

Registers FlutterSharp services in the dependency injection container.

```csharp
public static IServiceCollection AddFlutterSharp(
    this IServiceCollection services,
    Action<Page> configureApp)
```

**Parameters:**
- `configureApp` - Callback to configure the FlutterSharp Page and build the UI

**Example:**

```csharp
builder.Services.AddFlutterSharp(page =>
{
    page.Title = "My App";
    page.Theme = "dark";

    // Build UI...
});
```

### Application Extensions

#### UseFlutterSharp

Adds FlutterSharp middleware to the ASP.NET Core pipeline.

```csharp
public static IApplicationBuilder UseFlutterSharp(
    this IApplicationBuilder app)
```

**Must be called after:**
- `app.UseRouting()` (if using routing)
- Other authentication/authorization middleware

**Example:**

```csharp
var app = builder.Build();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseFlutterSharp();  // Add FlutterSharp WebSocket support

app.MapControllers();
app.Run();
```

## Middleware

### FlutterSharpWebSocketMiddleware

Handles WebSocket connections at the `/ws` endpoint.

**Features:**
- Automatic WebSocket upgrade
- Session creation for each connection
- MessagePack serialization
- Connection lifecycle management
- Error handling and logging

**Default Endpoint:** `/ws`

## Configuration

### Page Configuration

Configure your FlutterSharp application in the `AddFlutterSharp` callback:

```csharp
builder.Services.AddFlutterSharp(page =>
{
    // Set page properties
    page.Title = "My Application";
    page.Theme = "light"; // or "dark"

    // Build UI tree
    var container = new Column();
    // Add controls...

    page.AddChild(container);
});
```

### WebSocket Configuration

The WebSocket endpoint uses default ASP.NET Core WebSocket options. To customize:

```csharp
var builder = WebApplication.CreateBuilder(args);

// Configure WebSocket options
builder.Services.AddWebSockets(options =>
{
    options.KeepAliveInterval = TimeSpan.FromMinutes(2);
    options.AllowedOrigins.Add("https://example.com");
});

builder.Services.AddFlutterSharp(page => { /* ... */ });

var app = builder.Build();
app.UseFlutterSharp();
app.Run();
```

### Logging

FlutterSharp.Web uses standard ASP.NET Core logging:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Debug);

builder.Services.AddFlutterSharp(page => { /* ... */ });
```

## Usage Examples

### Interactive Counter

```csharp
builder.Services.AddFlutterSharp(page =>
{
    page.Title = "Counter Demo";

    var column = new Column
    {
        HorizontalAlignment = "center",
        VerticalAlignment = "center"
    };

    var counter = new Text("0") { Size = 48, Color = "blue" };

    int count = 0;
    var button = new ElevatedButton("Increment");
    button.Click += (sender, e) =>
    {
        count++;
        counter.Value = count.ToString();
    };

    column.AddChild(new Text("Counter") { Size = 32, Weight = "bold" });
    column.AddChild(counter);
    column.AddChild(button);

    page.AddChild(column);
});
```

### Form with Text Input

```csharp
builder.Services.AddFlutterSharp(page =>
{
    page.Title = "Form Demo";

    var column = new Column { Spacing = 10 };

    var nameField = new TextField
    {
        Label = "Enter your name",
        Autofocus = true
    };

    var resultText = new Text("") { Size = 18 };

    var submitButton = new ElevatedButton("Submit");
    submitButton.Click += (sender, e) =>
    {
        resultText.Value = $"Hello, {nameField.Value}!";
    };

    column.AddChild(nameField);
    column.AddChild(submitButton);
    column.AddChild(resultText);

    page.AddChild(column);
});
```

### Navigation with Tabs

```csharp
builder.Services.AddFlutterSharp(page =>
{
    page.Title = "Tabs Demo";

    var tabs = new NavigationBar { SelectedIndex = 0 };

    var homeTab = new NavigationBarDestination
    {
        Icon = "home",
        Label = "Home"
    };

    var settingsTab = new NavigationBarDestination
    {
        Icon = "settings",
        Label = "Settings"
    };

    tabs.AddChild(homeTab);
    tabs.AddChild(settingsTab);

    var content = new Text("Home Content") { Size = 24 };

    tabs.Change += (sender, e) =>
    {
        content.Value = tabs.SelectedIndex == 0
            ? "Home Content"
            : "Settings Content";
    };

    var column = new Column();
    column.AddChild(tabs);
    column.AddChild(content);

    page.AddChild(column);
});
```

## Integration with Existing Applications

### Adding to Existing ASP.NET Core Apps

FlutterSharp.Web works alongside existing ASP.NET Core features:

```csharp
var builder = WebApplication.CreateBuilder(args);

// Existing services
builder.Services.AddControllers();
builder.Services.AddRazorPages();

// Add FlutterSharp
builder.Services.AddFlutterSharp(page => { /* ... */ });

var app = builder.Build();

// Existing middleware
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Add FlutterSharp WebSocket support
app.UseFlutterSharp();

// Existing endpoints
app.MapControllers();
app.MapRazorPages();

app.Run();
```

### Using with Authentication

```csharp
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddFlutterSharp(page =>
{
    // Page configuration...
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseFlutterSharp();  // WebSocket connections respect auth

app.Run();
```

### Using with CORS

```csharp
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://example.com")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddFlutterSharp(page => { /* ... */ });

var app = builder.Build();

app.UseCors();
app.UseFlutterSharp();

app.Run();
```

## Deployment

### Production Configuration

```csharp
var builder = WebApplication.CreateBuilder(args);

// Production logging
if (builder.Environment.IsProduction())
{
    builder.Logging.AddConsole();
    builder.Logging.SetMinimumLevel(LogLevel.Warning);
}

builder.Services.AddFlutterSharp(page => { /* ... */ });

var app = builder.Build();

// HTTPS redirection in production
if (app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

app.UseFlutterSharp();
app.Run();
```

### Docker Deployment

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["MyApp.csproj", "./"]
RUN dotnet restore
COPY . .
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyApp.dll"]
```

## Troubleshooting

### WebSocket Connection Fails

**Issue:** Client cannot connect to WebSocket endpoint

**Solutions:**
1. Ensure server is running
2. Verify WebSocket URL is correct (`ws://` or `wss://`)
3. Check firewall settings
4. Confirm `app.UseFlutterSharp()` is called

### UI Not Updating

**Issue:** Control property changes don't reflect in UI

**Solutions:**
1. Ensure you're modifying control properties (not local variables)
2. Check event handlers are properly registered
3. Verify control is added to page tree

### Build Errors

**Issue:** Package references not found

**Solutions:**
```bash
# Restore dependencies
dotnet restore

# Clean and rebuild
dotnet clean
dotnet build
```

## Performance Considerations

### Connection Management

Each WebSocket connection creates a session. For high-traffic applications:

```csharp
builder.Services.AddWebSockets(options =>
{
    options.KeepAliveInterval = TimeSpan.FromMinutes(2);
});
```

### MessagePack Serialization

FlutterSharp uses MessagePack for efficient binary serialization. No configuration needed.

## Security

### HTTPS in Production

Always use HTTPS in production:

```csharp
if (app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}
```

### WebSocket Origin Validation

Validate WebSocket origins:

```csharp
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://yourdomain.com")
              .AllowCredentials();
    });
});
```

## Sample Applications

See the [samples](../../samples) directory for complete examples:

- **WebApp** - Counter demo with ASP.NET Core integration

## Resources

- [FlutterSharp Core Documentation](../FlutterSharp.Core/README.md)
- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [WebSocket Protocol](https://tools.ietf.org/html/rfc6455)
- [MessagePack Specification](https://msgpack.org)

## License

FlutterSharp.Web is part of the FlutterSharp project and is licensed under the MIT License.
