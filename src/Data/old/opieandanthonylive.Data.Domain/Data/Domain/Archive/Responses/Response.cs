using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;

namespace opieandanthonylive.Data.Domain.Archive.Responses
{
  [DebuggerDisplay("{DebuggerDisplay}")]
  public class Response
  {
    public int NumFound { get; set; }

    public int Start { get; set; }

    public List<Doc> Docs { get; set; }

    [JsonIgnore]
    public string DebuggerDisplay
    {
      get => $"Total: {NumFound} | Start: {Start}";
    }
  }
}