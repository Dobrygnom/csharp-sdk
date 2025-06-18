using ModelContextProtocol.Protocol;
using System.IO.Pipelines;
using System.Threading.Channels;

namespace ModelContextProtocol.Server;

/// <summary>
/// Handles processing the request/response body pairs for the Streamable HTTP transport.
/// This is typically used via <see cref="JsonRpcMessage.RelatedTransport"/>.
/// </summary>
internal sealed class StreamableHttpPostTransport(StreamableHttpServerTransport parentTransport, IDuplexPipe httpBodies) : ITransport
{
    public StreamableHttpServerTransport ParentTransport { get; } = parentTransport;
    public IDuplexPipe HttpBodies { get; } = httpBodies;

    public ValueTask DisposeAsync()
    {
        throw new NotImplementedException();
    }

    public ChannelReader<JsonRpcMessage> MessageReader { get; set; } = null!;
    public Task SendMessageAsync(JsonRpcMessage message, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
