using opieandanthonylive.Common.Query;

namespace opieandanthonylive.Data.API.Audible.Query
{
  internal interface IAudibleQueryBuilder
  {
    AudibleQueryBuilder WithAuthor(
      string author);
    
    AudibleQueryBuilder WithSearchRank(
      AudibleQueryField searchRankField);

    AudibleQueryBuilder WithFieldLanguage(
      AudibleFieldLanguage fieldLanguage);

    AudibleQueryBuilder WithSort(
      AudibleQueryField sortField,
      SortDirection sortDirection);

    AudibleQueryBuilder WithSearchSize(
      uint searchSize);

    AudibleQueryBuilder OnPageNumber(
      uint pageNumber);

    AudibleQueryBuilder WithSearchRankSelect(
      AudibleQueryField searchRankSelectField,
      SortDirection searchRankSelectDirection);
  }
}