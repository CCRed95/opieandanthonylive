using Ccr.Dnc.Core.Extensions;

namespace opieandanthonylive.Data.API.Archive.Query
{
  public static class ArchiveQueryBuilderExtensions
  {
    public static ArchiveQueryBuilder WithUploader(
      this ArchiveQueryBuilder @this,
      string uploader)
    {
      return @this
        .As<IArchiveQueryBuilder>()
        .WithUploader(
          uploader);
    }

    public static ArchiveQueryBuilder WithSubject(
      this ArchiveQueryBuilder @this,
      string subject)
    {
      return @this
        .As<IArchiveQueryBuilder>()
        .WithSubject(
          subject);
    }

    public static ArchiveQueryBuilder WithFields(
      this ArchiveQueryBuilder @this,
      params ArchiveQueryField[] Field)
    {
      return @this
        .As<IArchiveQueryBuilder>()
        .WithFields(
          Field);
    }

    public static ArchiveQueryBuilder WithSort(
      this ArchiveQueryBuilder @this,
      ArchiveQueryField SortField,
      SortDirection sortDirection)
    {
      return @this
        .As<IArchiveQueryBuilder>()
        .WithSort(
          SortField,
          sortDirection);
    }

    public static ArchiveQueryBuilder WithRows(
      this ArchiveQueryBuilder @this,
      uint rowCount)
    {
      return @this
        .As<IArchiveQueryBuilder>()
        .WithRows(
          rowCount);
    }

    public static ArchiveQueryBuilder OnPageNumber(
      this ArchiveQueryBuilder @this,
      uint pageNumber)
    {
      return @this
        .As<IArchiveQueryBuilder>()
        .OnPageNumber(
          pageNumber);
    }

    public static ArchiveQueryBuilder WithOutputKind(
      this ArchiveQueryBuilder @this,
      APIDataOutputKind dataOutputKind)
    {
      return @this
        .As<IArchiveQueryBuilder>()
        .WithOutputKind(
          dataOutputKind);
    }

    public static ArchiveQueryBuilder WithCallback(
      this ArchiveQueryBuilder @this,
      string callback)
    {
      return @this
        .As<IArchiveQueryBuilder>()
        .WithCallback(
          callback);
    }

    public static ArchiveQueryBuilder WithShouldSave(
      this ArchiveQueryBuilder @this,
      bool shouldSave)
    {
      return @this
        .As<IArchiveQueryBuilder>()
        .WithShouldSave(
          shouldSave);
    }
  }
}