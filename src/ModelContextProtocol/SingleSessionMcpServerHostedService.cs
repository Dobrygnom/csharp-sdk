using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Server;

namespace ModelContextProtocol;

/// <summary>
/// Hosted service for a single-session (e.g. stdio) MCP server.
/// </summary>
/// <param name="session">The server representing the session being hosted.</param>
internal sealed class SingleSessionMcpServerHostedService(IMcpServer session) : BackgroundService
{
    /// <inheritdoc />
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await session.RunAsync(stoppingToken).ConfigureAwait(false);
    }
}
