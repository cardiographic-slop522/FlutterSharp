using FlutterSharp.Core.Controls;
using FlutterSharp.Core.Session;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FlutterSharp.Web.Extensions;

/// <summary>
/// Extension methods for adding FlutterSharp services to the DI container.
/// </summary>
public static class FlutterSharpServiceExtensions
{
    /// <summary>
    /// Adds FlutterSharp services to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configureApp">Action to configure the FlutterSharp application page.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddFlutterSharp(
        this IServiceCollection services,
        Action<Page> configureApp)
    {
        // Register Page as singleton
        services.AddSingleton(sp =>
        {
            var page = new Page();
            configureApp(page);
            return page;
        });

        // Register SessionManager as singleton
        services.AddSingleton(sp =>
        {
            var logger = sp.GetService<ILogger<SessionManager>>();
            return new SessionManager(logger);
        });

        return services;
    }

    /// <summary>
    /// Adds FlutterSharp services to the service collection with a factory function.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="pageFactory">Factory function to create the Page instance.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddFlutterSharp(
        this IServiceCollection services,
        Func<IServiceProvider, Page> pageFactory)
    {
        // Register Page as singleton with factory
        services.AddSingleton(pageFactory);

        // Register SessionManager as singleton
        services.AddSingleton(sp =>
        {
            var logger = sp.GetService<ILogger<SessionManager>>();
            return new SessionManager(logger);
        });

        return services;
    }
}
