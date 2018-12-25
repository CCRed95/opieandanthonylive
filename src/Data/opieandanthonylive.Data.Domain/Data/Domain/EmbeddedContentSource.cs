using System.Runtime.CompilerServices;
using Ccr.Data.EntityFrameworkCore.Infrastucture;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;

namespace opieandanthonylive.Data.Domain
{
  ////[EntityConfigurator(typeof(EmbeddedContentSourceMap))]
  public partial class EmbeddedContentSource
    : EntityBase
  {
    public int EmbeddedContentSourceID { get; set; }

    public string EmbeddedContentSourceName { get; set; }


    private EmbeddedContentSource() { }

    public EmbeddedContentSource(
      [NotNull] string embeddedContentSourceName) : this()
    {
      embeddedContentSourceName.IsNotNull(nameof(embeddedContentSourceName));

      EmbeddedContentSourceName = embeddedContentSourceName;
    }

    private EmbeddedContentSource(
      int embeddedContentSourceID,
      [CallerMemberName] string memberName = "") : this(
        memberName.Replace('_', ' '))
    {
      EmbeddedContentSourceID = embeddedContentSourceID;
    }
  }
}
