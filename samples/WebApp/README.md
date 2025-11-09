# FlutterSharp Web Application Sample

This sample demonstrates how to use FlutterSharp with ASP.NET Core to create a web application with Flutter UI and C# backend.

## Overview

This is a simple counter application that shows:
- ASP.NET Core integration with FlutterSharp.Web
- WebSocket communication between Flutter client and C# backend
- Reactive UI updates when state changes
- Event handling (button clicks)

## Project Structure

```
WebApp/
├── Program.cs           # Main application entry point
├── WebApp.csproj       # Project file with FlutterSharp.Web reference
└── README.md           # This file
```

## How It Works

### 1. Add FlutterSharp Services

In `Program.cs`, FlutterSharp services are added to the DI container:

```csharp
builder.Services.AddFlutterSharp(page =>
{
    page.Title = "FlutterSharp Counter Demo";
    page.Theme = "light";

    // Build your UI here
    var column = new Column { ... };
    // Add controls...
    page.AddChild(column);
});
```

### 2. Enable FlutterSharp Middleware

The middleware enables WebSocket connections at `/ws`:

```csharp
app.UseFlutterSharp();
```

### 3. Run the Application

```bash
dotnet run
```

The server will start on `http://localhost:5000` (or `https://localhost:5001` for HTTPS).

## WebSocket Endpoint

The FlutterSharp WebSocket endpoint is available at:
- **WebSocket URL:** `ws://localhost:5000/ws` (or `wss://localhost:5001/ws` for HTTPS)

## Connecting a Flutter Client

To connect a Flutter/Flet client to this server:

1. **Using Flet Python Client:**
   ```python
   import flet as ft

   def main(page: ft.Page):
       # Connect to custom server
       pass

   ft.app(target=main, view=ft.WEB_BROWSER)
   ```

2. **Using WebSocket directly (JavaScript):**
   ```javascript
   const ws = new WebSocket('ws://localhost:5000/ws');

   ws.onopen = () => {
       console.log('Connected to FlutterSharp server');
   };

   ws.onmessage = (event) => {
       // Handle MessagePack binary messages
       console.log('Received message:', event.data);
   };
   ```

## Features Demonstrated

### Reactive UI
When the button is clicked, the counter increments and the UI automatically updates:
```csharp
int count = 0;
var button = new ElevatedButton("Increment");
button.Click += (sender, e) =>
{
    count++;
    counter.Value = count.ToString(); // UI updates automatically
};
```

### FlutterSharp Controls Used
- **Page** - Root container with title and theme
- **Column** - Vertical layout container
- **Text** - Text display with styling (size, color, weight)
- **ElevatedButton** - Material Design button with click event

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
│  FlutterSharp.Core  │
│  - Controls         │
│  - Session Manager  │
│  - Protocol         │
└─────────────────────┘
```

## Next Steps

### Enhance the Application

1. **Add More Controls:**
   ```csharp
   var textField = new TextField { Label = "Enter name" };
   var checkbox = new Checkbox { Label = "Agree to terms" };
   ```

2. **Add Navigation:**
   ```csharp
   page.OnRouteChange += (sender, e) =>
   {
       // Handle route changes
   };
   ```

3. **Add Data Binding:**
   ```csharp
   var dataTable = new DataTable();
   // Bind data...
   ```

### Deploy to Production

1. **Enable HTTPS:**
   ```csharp
   app.UseHttpsRedirection();
   ```

2. **Configure Logging:**
   ```csharp
   builder.Logging.AddConsole();
   ```

3. **Add CORS (if needed):**
   ```csharp
   builder.Services.AddCors(options =>
   {
       options.AddDefaultPolicy(policy =>
       {
           policy.AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader();
       });
   });
   ```

## Troubleshooting

### WebSocket Connection Issues
- Ensure the server is running before connecting clients
- Check firewall settings allow WebSocket connections
- Verify the WebSocket URL is correct (ws:// or wss://)

### Build Errors
```bash
# Restore dependencies
dotnet restore

# Clean and rebuild
dotnet clean
dotnet build
```

## Resources

- [FlutterSharp Documentation](../../README.md)
- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [Flet Framework](https://flet.dev)
- [WebSocket Protocol](https://tools.ietf.org/html/rfc6455)

## License

This sample is part of the FlutterSharp project and is licensed under the MIT License.
