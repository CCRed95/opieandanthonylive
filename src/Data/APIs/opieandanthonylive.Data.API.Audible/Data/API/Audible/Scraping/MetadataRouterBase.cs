using AngleSharp.Dom;
using opieandanthonylive.Data.Domain.Audible;

namespace opieandanthonylive.Data.API.Audible.Scraping
{
  public abstract class MetadataRouterBase
  {
    public abstract void ExecutePropertySetBase(
      AudibleMediaItem @this,
      object value);

    public abstract object ScrapeBase(
      IElement element);
  }
}