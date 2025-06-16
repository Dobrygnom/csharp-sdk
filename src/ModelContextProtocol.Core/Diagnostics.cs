using ModelContextProtocol.Protocol;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ModelContextProtocol;

internal static class Diagnostics
{
    internal static ActivitySource ActivitySource { get; } = new("Experimental.ModelContextProtocol");

    internal static Meter Meter { get; } = new("Experimental.ModelContextProtocol");

    internal static Histogram<double> CreateDurationHistogram(string name, string description, bool longBuckets) =>
        Diagnostics.Meter.CreateHistogram<double>(name, "s", description
        );
    internal static bool ShouldInstrumentMessage(JsonRpcMessage message) =>
        ActivitySource.HasListeners() &&
        message switch
        {
            JsonRpcRequest => true,
            JsonRpcNotification notification => notification.Method != NotificationMethods.LoggingMessageNotification,
            _ => false
        };

    internal static ActivityLink[] ActivityLinkFromCurrent() => Activity.Current is null ? [] : [new ActivityLink(Activity.Current.Context)];
}
