using Ccr.Std.Core.Extensions;
using opieandanthonylive.Data.API.Common.Query;

namespace opieandanthonylive.Data.API.Audible.Query
{
  public static class AudibleQueryBuilderExtensions
  {
    public static AudibleQueryBuilder WithAuthor(
      this AudibleQueryBuilder @this,
      string author)
    {
      return @this
        .As<IAudibleQueryBuilder>()
        .WithAuthor(
          author);
    }

    public static AudibleQueryBuilder WithSearchRank(
      this AudibleQueryBuilder @this,
      AudibleQueryField searchRankField)
    {
      return @this
        .As<IAudibleQueryBuilder>()
        .WithSearchRank(
          searchRankField);
    }

    public static AudibleQueryBuilder WithFieldLanguage(
      this AudibleQueryBuilder @this,
      AudibleFieldLanguage fieldLanguage)
    {
      return @this
        .As<IAudibleQueryBuilder>()
        .WithFieldLanguage(
          fieldLanguage);
    }

    public static AudibleQueryBuilder WithSort(
      this AudibleQueryBuilder @this,
      AudibleQueryField sortField,
      SortDirection sortDirection)
    {
      return @this
        .As<IAudibleQueryBuilder>()
        .WithSort(
          sortField,
          sortDirection);
    }

    public static AudibleQueryBuilder WithSearchSize(
      this AudibleQueryBuilder @this,
      uint searchSize)
    {
      return @this
        .As<IAudibleQueryBuilder>()
        .WithSearchSize(
          searchSize);
    }

    public static AudibleQueryBuilder OnPageNumber(
      this AudibleQueryBuilder @this,
      uint pageNumber)
    {
      return @this
        .As<IAudibleQueryBuilder>()
        .OnPageNumber(
          pageNumber);
    }

    public static AudibleQueryBuilder WithSearchRankSelect(
      this AudibleQueryBuilder @this,
      AudibleQueryField searchRankSelectField,
      SortDirection searchRankSelectDirection)
    {
      return @this
        .As<IAudibleQueryBuilder>()
        .WithSearchRankSelect(
          searchRankSelectField,
          searchRankSelectDirection);
    }
  }
}
