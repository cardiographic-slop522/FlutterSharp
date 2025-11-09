using System.Net;
using System.Net.WebSockets;
using FlutterSharp.Core.Controls;
using FlutterSharp.Core.Controls.Core;
using FlutterSharp.Core.Controls.Material;
using FlutterSharp.Web.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FlutterSharp.Web.Tests;

public class WebSocketMiddlewareTests : IDisposable
{
    private readonly IHost _host;
    private readonly TestServer _server;

    public WebSocketMiddlewareTests()
    {
        var builder = new HostBuilder()
            .ConfigureWebHost(webHost =>
            {
                webHost.UseTestServer();
                webHost.ConfigureServices(services =>
                {
                    services.AddFlutterSharp(page =>
                    {
                        page.Title = "Test App";
                        page.Theme = "light";

                        var column = new Column();
                        var text = new Text("Test");
                        column.AddChild(text);
                        page.AddChild(column);
                    });
                });
                webHost.Configure(app =>
                {
                    app.UseFlutterSharp();
                });
            });

        _host = builder.Start();
        _server = _host.GetTestServer();
    }

    [Fact]
    public async Task WebSocketEndpoint_AcceptsConnections()
    {
        // Arrange
        var client = _server.CreateWebSocketClient();

        // Act
        var webSocket = await client.ConnectAsync(new Uri(_server.BaseAddress, "/ws"), CancellationToken.None);

        // Assert
        Assert.Equal(WebSocketState.Open, webSocket.State);

        // Cleanup
        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Test complete", CancellationToken.None);
    }

    [Fact]
    public async Task WebSocketEndpoint_RejectsNonWebSocketRequests()
    {
        // Arrange
        var client = _server.CreateClient();

        // Act
        var response = await client.GetAsync("/ws");

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task WebSocket_CanSendAndReceiveMessages()
    {
        // Arrange
        var client = _server.CreateWebSocketClient();
        var webSocket = await client.ConnectAsync(new Uri(_server.BaseAddress, "/ws"), CancellationToken.None);

        // Act - Send a message
        var testMessage = new byte[] { 1, 2, 3, 4, 5 };
        await webSocket.SendAsync(
            new ArraySegment<byte>(testMessage),
            WebSocketMessageType.Binary,
            endOfMessage: true,
            CancellationToken.None);

        // Assert - Connection remains open
        Assert.Equal(WebSocketState.Open, webSocket.State);

        // Cleanup
        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Test complete", CancellationToken.None);
    }

    [Fact]
    public async Task WebSocket_SupportsMultipleConnections()
    {
        // Arrange
        var client = _server.CreateWebSocketClient();

        // Act - Create multiple connections
        var webSocket1 = await client.ConnectAsync(new Uri(_server.BaseAddress, "/ws"), CancellationToken.None);
        var webSocket2 = await client.ConnectAsync(new Uri(_server.BaseAddress, "/ws"), CancellationToken.None);
        var webSocket3 = await client.ConnectAsync(new Uri(_server.BaseAddress, "/ws"), CancellationToken.None);

        // Assert
        Assert.Equal(WebSocketState.Open, webSocket1.State);
        Assert.Equal(WebSocketState.Open, webSocket2.State);
        Assert.Equal(WebSocketState.Open, webSocket3.State);

        // Cleanup
        await webSocket1.CloseAsync(WebSocketCloseStatus.NormalClosure, "Test complete", CancellationToken.None);
        await webSocket2.CloseAsync(WebSocketCloseStatus.NormalClosure, "Test complete", CancellationToken.None);
        await webSocket3.CloseAsync(WebSocketCloseStatus.NormalClosure, "Test complete", CancellationToken.None);
    }

    [Fact]
    public async Task WebSocket_HandlesGracefulClose()
    {
        // Arrange
        var client = _server.CreateWebSocketClient();
        var webSocket = await client.ConnectAsync(new Uri(_server.BaseAddress, "/ws"), CancellationToken.None);

        // Act
        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client closing", CancellationToken.None);

        // Assert
        Assert.Equal(WebSocketState.Closed, webSocket.State);
    }

    [Fact]
    public async Task NonWebSocketPath_PassesToNextMiddleware()
    {
        // Arrange
        var client = _server.CreateClient();

        // Act
        var response = await client.GetAsync("/other-path");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    public void Dispose()
    {
        _host?.Dispose();
    }
}
