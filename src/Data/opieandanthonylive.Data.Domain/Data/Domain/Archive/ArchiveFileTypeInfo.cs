namespace opieandanthonylive.Data.Domain.Archive
{
  public partial class ArchiveFileTypeInfo
  {
    public int ArchiveFileTypeInfoID { get; set; }

    public string Extension { get; set; }

    public string Description { get; set; }


    public ArchiveFileTypeInfo(
      string extension,
      string description)
    {
      Extension = extension;
      Description = description;
    }

    private ArchiveFileTypeInfo(
      int archiveFileTypeInfoID,
      string extension,
      string description)
        : this(
          extension,
          description)
    {
      ArchiveFileTypeInfoID = archiveFileTypeInfoID;
    }
  }
}