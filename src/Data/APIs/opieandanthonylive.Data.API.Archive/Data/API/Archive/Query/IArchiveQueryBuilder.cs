namespace opieandanthonylive.Data.API.Archive.Query
{
  internal interface IArchiveQueryBuilder
  {
    ArchiveQueryBuilder WithUploader(
      string uploader);

    ArchiveQueryBuilder WithSubject(
      string subject);

    ArchiveQueryBuilder WithFields(
      params ArchiveQueryField[] Field);

    ArchiveQueryBuilder WithSort(
      ArchiveQueryField Field,
      SortDirection direction);

    ArchiveQueryBuilder WithRows(
      uint rowCount);

    ArchiveQueryBuilder OnPageNumber(
      uint pageNumber);

    ArchiveQueryBuilder WithOutputKind(
      APIDataOutputKind dataOutputKind);

    ArchiveQueryBuilder WithCallback(
      string callback);

    ArchiveQueryBuilder WithShouldSave(
      bool shouldSave);
  }
}