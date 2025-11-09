using FlutterSharp.Web.Middleware;
using Microsoft.AspNetCore.Builder;

namespace FlutterSharp.Web.Extensions;

/// <summary>
/// Extension methods for configuring FlutterSharp middleware in the ASP.NET Core pipeline.
/// </summary>
public static class FlutterSharpApplicationExtensions
{
    /// <summary>
    /// Adds FlutterSharp WebSocket middleware to the application pipeline.
    /// This should be called after UseRouting() but before UseEndpoints().
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <returns>The application builder for chaining.</returns>
    public static IApplicationBuilder UseFlutterSharp(this IApplicationBuilder app)
    {
        // Enable WebSockets
        app.UseWebSockets();

        // Add FlutterSharp WebSocket middleware
        app.UseMiddleware<FlutterSharpWebSocketMiddleware>();

        return app;
    }
}
