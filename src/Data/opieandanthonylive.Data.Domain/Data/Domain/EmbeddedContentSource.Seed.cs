using Ccr.Dnc.Data.EntityFrameworkCore;
using opieandanthonylive.Data.Domain.Complex;

namespace opieandanthonylive.Data.Domain
{
  public partial class EmbeddedContentSource
    : ISeedableEntity
  {
    public static EmbeddedContentSource Archive
      = EntityFactory.Create<EmbeddedContentSource>();

    public static EmbeddedContentSource YouTube
      = EntityFactory.Create<EmbeddedContentSource>();
  }
}