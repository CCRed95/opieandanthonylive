using System;
using System.Text;
using Ccr.Dnc.Core.Extensions;
using opieandanthonylive.Data.API.Common.Query;
using opieandanthonylive.Data.API.Infrastructure;

namespace opieandanthonylive.Data.API.Audible.Query
{
  public class AudibleQueryBuilder
    : IAudibleQueryBuilder,
      IQueryBuilder
  {
    private string _author;
    private AudibleQueryField? _searchRankField;
    private AudibleFieldLanguage? _fieldLanguage;
    private AudibleQueryField? _sortField;
    private SortDirection? _sortDirection;
    private uint? _searchSize;
    private uint? _pageNumber;
    private AudibleQueryField? _searchRankSelectField;
    private SortDirection? _searchRankSelectDirection;



    AudibleQueryBuilder IAudibleQueryBuilder.WithAuthor(
      string author)
    {
      if (_author != null)
        throw new InvalidOperationException(
          $"The author cannot be set to {author.Quote()} because the instance of " +
          $"{nameof(AudibleQueryBuilder).SQuote()} already has the author {_author.Quote()}.");

      _author = author;
      return this;
    }

    AudibleQueryBuilder IAudibleQueryBuilder.WithSearchRank(
      AudibleQueryField searchRankField)
    {
      if (_searchRankField != null)
        throw new InvalidOperationException(
          $"The searchRankField cannot be set to {searchRankField.ToString().SQuote()} because the " +
          $"instance of {nameof(AudibleQueryBuilder).SQuote()} already has the searchRankField " +
          $"{_searchRankField.ToString().ToLower().SQuote()}.");

      _searchRankField = searchRankField;
      return this;
    }

    AudibleQueryBuilder IAudibleQueryBuilder.WithFieldLanguage(
      AudibleFieldLanguage fieldLanguage)
    {
      if (_fieldLanguage != null)
        throw new InvalidOperationException(
          $"The fieldLanguage cannot be set to {fieldLanguage.ToString().SQuote()} because the " +
          $"instance of {nameof(AudibleQueryBuilder).SQuote()} already has the fieldLanguage " +
          $"{_fieldLanguage.ToString().ToLower().SQuote()}.");

      _fieldLanguage = fieldLanguage;
      return this;
    }

    AudibleQueryBuilder IAudibleQueryBuilder.WithSort(
      AudibleQueryField sortField, 
      SortDirection sortDirection)
    {
      if (_sortField != null)
        throw new InvalidOperationException(
          $"The sortField cannot be set to {sortField.ToString().ToLower().SQuote()} because the " +
          $"instance of {nameof(AudibleQueryBuilder).SQuote()} already has the sortField " +
          $"{_sortField.ToString().ToLower().SQuote()}.");

      _sortField = sortField;

      if (_sortDirection != null)
        throw new InvalidOperationException(
          $"The sortDirection cannot be set to {sortDirection.ToString().ToLower().SQuote()} because the " +
          $"instance of {nameof(AudibleQueryBuilder).SQuote()} already has the sortDirection " +
          $"{_sortDirection.ToString().ToLower().SQuote()}.");

      _sortDirection = sortDirection;

      return this;
    }

    AudibleQueryBuilder IAudibleQueryBuilder.WithSearchSize(
      uint searchSize)
    {
      if (_searchSize != null)
        throw new InvalidOperationException(
          $"The fieldLanguage cannot be set to {searchSize.ToString().SQuote()} because the " +
          $"instance of {nameof(AudibleQueryBuilder).SQuote()} already has the searchSize " +
          $"{_searchSize.ToString().ToLower().SQuote()}.");

      _searchSize = searchSize;
      return this;
    }

    AudibleQueryBuilder IAudibleQueryBuilder.OnPageNumber(
      uint pageNumber)
    {
      if (_pageNumber != null)
        throw new InvalidOperationException(
          $"The pageNumber cannot be set to {pageNumber.ToString().SQuote()} because the instance of " +
          $"{nameof(AudibleQueryBuilder).SQuote()} already has the pageNumber " +
          $"{_pageNumber.ToString().Quote()}.");

      _pageNumber = pageNumber;
      return this;
    }

    AudibleQueryBuilder IAudibleQueryBuilder.WithSearchRankSelect(
      AudibleQueryField searchRankSelectField,
      SortDirection searchRankSelectDirection)
    {
      if (_searchRankSelectField != null)
        throw new InvalidOperationException(
          $"The searchRankSelectField cannot be set to {searchRankSelectField.ToString().ToLower().SQuote()} " +
          $"because the instance of {nameof(AudibleQueryBuilder).SQuote()} already has the " +
          $"searchRankSelectField {_searchRankSelectField.ToString().ToLower().SQuote()}.");

      _searchRankSelectField = searchRankSelectField;

      if (_searchRankSelectDirection != null)
        throw new InvalidOperationException(
          $"The searchRankSelectDirection cannot be set to " +
          $"{searchRankSelectDirection.ToString().ToLower().Quote()} because the instance of " +
          $"{nameof(AudibleQueryBuilder).SQuote()} already has the searchRankSelectDirection " +
          $"{_searchRankSelectDirection.ToString().ToLower().SQuote()}.");

      _searchRankSelectDirection = searchRankSelectDirection;
      return this;
    }

    

    public string BuilldRequestUrl(
      DomainFragment requestBuilder)
    {
      var uriBuilder = requestBuilder
        .Builder
        .WithPath("search/");

      if (_searchRankField.HasValue)
      {
        var sb = new StringBuilder();

        sb.Append("ref=");
        sb.Append("sr_sort_");
        sb.Append(_searchRankField.ToString().ToLower());

        uriBuilder
          .WithPath(
            sb.ToString());
      }

      if (_author != null)
      {
        uriBuilder.WithParameter("searchAuthor", _author);
      }

      if (_sortDirection.HasValue && _sortField.HasValue)
      {
        var sb = new StringBuilder();

        sb.Append(_sortField.ToString().ToLower());
        sb.Append("Sorter ");

        switch (_sortDirection)
        {
          case SortDirection.Ascending:
            sb.Append("asc");
            break;
          case SortDirection.Descending:
            sb.Append("desc");
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }

        uriBuilder.WithParameter("sort[]", sb.ToString());
      }

      if (_searchRankField.HasValue)
      {
        uriBuilder.WithParameter("searchRank", _searchRankField.ToString().ToLower());
      }

      if (_fieldLanguage.HasValue)
      {
        uriBuilder.WithParameter("field_language", ((long)_fieldLanguage).ToString().ToLower());
      }

      if (_searchSize.HasValue)
      {
        uriBuilder.WithParameter("searchSize", _searchSize.ToString());
      }

      if (_pageNumber.HasValue)
      {
        uriBuilder.WithParameter("page", _pageNumber.ToString());
      }

      
      if (_searchRankSelectField.HasValue && _searchRankSelectDirection.HasValue)
      {
        var sb = new StringBuilder();

        switch (_sortDirection)
        {
          case SortDirection.Ascending:
            sb.Append("+");
            break;
          case SortDirection.Descending:
            sb.Append("-");
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }

        sb.Append(_searchRankSelectField.ToString().ToLower());
        
        uriBuilder.WithParameter("searchRankSelect", sb.ToString());
      }

      return uriBuilder.Build();
    }
  }
}
