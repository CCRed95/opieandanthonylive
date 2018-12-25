using System;
using Ccr.Data.EntityFrameworkCore.Infrastucture;

namespace opieandanthonylive.Data.Domain.Audible
{
  public class AudibleMediaItem
    : EntityBase
  {
    public int AudibleMediaItemID { get; set; }

    public string ItemTypeClassification { get; set; }

    public string Title { get; set; }

    public string By { get; set; }

    public string NarratedBy { get; set; }

    public string FullShowMetadataUrl { get; set; }

    public TimeSpan PlaybackLength { get; set; }

    public DateTime ReleaseDate { get; set; }

    public double? AverageRating { get; set; }

    public int NumberOfRatings { get; set; }
  }
}
