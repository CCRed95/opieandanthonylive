using System.Diagnostics;
using Newtonsoft.Json;

namespace opieandanthonylive.Data.Domain.Archive.Responses
{
  [DebuggerDisplay("{DebuggerDisplay}")]
  public class ResponseHeader
  {
    [JsonProperty("status")]
    internal int Status { get; set; }

    [JsonProperty("QTime")]
    internal int QueryTime { get; set; }

    [JsonProperty("params")]
    internal Params Parameters { get; set; }

    [JsonIgnore]
    public string DebuggerDisplay
    {
      get => $"Header: {QueryTime}ms | {Status}";
    }
  }
}