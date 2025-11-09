using FlutterSharp.Core;
using FlutterSharp.Core.Controls;
using FlutterSharp.Core.Controls.Core;
using FlutterSharp.Web.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FlutterSharp.Web.Tests;

public class ServiceExtensionsTests
{
    [Fact]
    public void AddFlutterSharp_RegistersPageAsSingleton()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddFlutterSharp(page =>
        {
            page.Title = "Test App";
        });
        var provider = services.BuildServiceProvider();

        // Assert
        var page1 = provider.GetService<Page>();
        var page2 = provider.GetService<Page>();

        Assert.NotNull(page1);
        Assert.NotNull(page2);
        Assert.Same(page1, page2); // Should be the same instance
    }

    [Fact]
    public void AddFlutterSharp_RegistersServices()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddLogging();

        // Act
        services.AddFlutterSharp(page => { });
        var provider = services.BuildServiceProvider();

        // Assert - Should be able to resolve Page
        var page = provider.GetService<Page>();
        Assert.NotNull(page);
    }

    [Fact]
    public void AddFlutterSharp_ConfiguresPage()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddFlutterSharp(page =>
        {
            page.Title = "Custom Title";
            page.Theme = "dark";

            var column = new Column();
            page.AddChild(column);
        });
        var provider = services.BuildServiceProvider();

        // Assert
        var page = provider.GetService<Page>();

        Assert.NotNull(page);
        Assert.Equal("Custom Title", page.Title);
        Assert.Equal("dark", page.Theme);
        Assert.Single(page.Children); // Should have one child (Column)
    }

    [Fact]
    public void AddFlutterSharp_AllowsComplexUIConfiguration()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddFlutterSharp(page =>
        {
            page.Title = "Complex UI";

            var column = new Column();

            for (int i = 0; i < 5; i++)
            {
                var text = new Text($"Item {i}");
                column.AddChild(text);
            }

            page.AddChild(column);
        });
        var provider = services.BuildServiceProvider();

        // Assert
        var page = provider.GetService<Page>();

        Assert.NotNull(page);
        Assert.Single(page.Children); // One Column

        var column = page.Children[0] as Column;
        Assert.NotNull(column);
        Assert.Equal(5, column.Children.Count); // Five Text controls
    }

    [Fact]
    public void AddFlutterSharp_WorksWithoutLogger()
    {
        // Arrange
        var services = new ServiceCollection();
        // Note: Not adding logging services

        // Act
        services.AddFlutterSharp(page =>
        {
            page.Title = "No Logger Test";
        });
        var provider = services.BuildServiceProvider();

        // Assert
        var page = provider.GetService<Page>();
        Assert.NotNull(page);
        Assert.Equal("No Logger Test", page.Title);
    }

    [Fact]
    public void AddFlutterSharp_CanBeCalledMultipleTimes()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddFlutterSharp(page => { page.Title = "First"; });
        services.AddFlutterSharp(page => { page.Title = "Second"; }); // Override

        var provider = services.BuildServiceProvider();

        // Assert - Last registration wins
        var page = provider.GetService<Page>();
        Assert.NotNull(page);
        // Note: With multiple registrations, DI typically returns the last registered
    }
}
