using ModelContextProtocol.Protocol;
using System.Buffers;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;

namespace ModelContextProtocol.Server;

internal sealed class SseWriter(string? messageEndpoint = null, BoundedChannelOptions? channelOptions = null) : IAsyncDisposable
{
    public string? MessageEndpoint { get; } = messageEndpoint;
    public BoundedChannelOptions? ChannelOptions { get; } = channelOptions;

    public ValueTask DisposeAsync()
    {
        throw new NotImplementedException();
    }
}
