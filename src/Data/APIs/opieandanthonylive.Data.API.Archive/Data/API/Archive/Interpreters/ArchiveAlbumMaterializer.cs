using opieandanthonylive.Data.Domain.Archive;
using opieandanthonylive.Data.Domain.Archive.Responses;

namespace opieandanthonylive.Data.API.Archive.Interpreters
{
  public static class ArchiveAlbumMaterializer
  {
    public static ArchiveAlbum CreateArchiveAlbum(
      Doc doc)
    {
      return new ArchiveAlbum(
        doc.Identifier,
        ContentCreator.Opie_and_Anthony,
        doc.Description,
        doc.Date,
        doc.Date.Year,
        doc.Date.Month,
        ArchiveFileMaterializer.ScrapeArchiveFiles);
    }
  }

}