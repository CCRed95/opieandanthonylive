using Ccr.Dnc.Data.EntityFrameworkCore;

namespace opieandanthonylive.Data.Domain.Archive
{
  public partial class ArchiveFileTypeInfo
    : ISeedableEntity
  {
    public static readonly ArchiveFileTypeInfo AFPK
      = new ArchiveFileTypeInfo(
        1,
        "AFPK",
        "Columbia Peaks Audio Fingerprint File");

    public static readonly ArchiveFileTypeInfo PNG
      = new ArchiveFileTypeInfo(
        2,
        "PNG",
        "Ping Image File");

    public static readonly ArchiveFileTypeInfo MP3
      = new ArchiveFileTypeInfo(
        3,
        "MP3",
        "M-PEG Layer III Audio File");

    public static readonly ArchiveFileTypeInfo OGG
      = new ArchiveFileTypeInfo(
        4,
        "OGG",
        "Xiph.Org Foundation Opus Lossy");

    public static readonly ArchiveFileTypeInfo Torrent
      = new ArchiveFileTypeInfo(
        5,
        "Torrent",
        "BitTorrent File Distribution System File");

    public static readonly ArchiveFileTypeInfo SQLite
      = new ArchiveFileTypeInfo(
        6,
        "SQLite",
        "SQLite Database File");

    public static readonly ArchiveFileTypeInfo XML
      = new ArchiveFileTypeInfo(
        7,
        "XML",
        "Extensible Markup Language File");

    public static readonly ArchiveFileTypeInfo Unknown
      = new ArchiveFileTypeInfo(
        8,
        "Unknown",
        "Unknown File Type");
  }

}
