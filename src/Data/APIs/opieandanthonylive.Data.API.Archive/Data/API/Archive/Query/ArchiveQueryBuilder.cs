using System;
using System.Linq;
using System.Text;
using Ccr.Std.Core.Extensions;
using opieandanthonylive.Data.API.Common.Query;
using opieandanthonylive.Data.API.Infrastructure;

namespace opieandanthonylive.Data.API.Archive.Query
{
  public class ArchiveQueryBuilder
    : IArchiveQueryBuilder,
      IQueryBuilder
  {
    private string _uploader;
    private string _subject;
    private ArchiveQueryField[] _fields;
    private ArchiveQueryField? _sortField;
    private SortDirection? _sortDirection;
    private uint? _rowCount;
    private uint? _onPageNumber;
    private APIDataOutputKind? _dataOutputKind;
    private string _callback;
    private bool? _shouldSave;



    ArchiveQueryBuilder IArchiveQueryBuilder.WithUploader(
      string uploader)
    {
      if (_uploader != null)
        throw new InvalidOperationException(
          $"The uploader cannot be set to {uploader.Quote()} because the instance of " +
          $"{nameof(ArchiveQueryBuilder).SQuote()} already has the uploader {_uploader.Quote()}.");

      _uploader = uploader;
      return this;
    }

    ArchiveQueryBuilder IArchiveQueryBuilder.WithSubject(
      string subject)
    {
      if (_subject != null)
        throw new InvalidOperationException(
          $"The subject cannot be set to {subject.Quote()} because the instance of " +
          $"{nameof(ArchiveQueryBuilder).SQuote()} already has the subject {_subject.Quote()}.");

      _subject = subject;
      return this;
    }

    ArchiveQueryBuilder IArchiveQueryBuilder.WithFields(
      params ArchiveQueryField[] fields)
    {
      if (_fields != null)
        throw new InvalidOperationException(
          $"The fields cannot be set to {fields.Aggregate("", (s, i) => s += i.ToString().ToLower()).Quote()} " +
          $"because the instance of {nameof(ArchiveQueryBuilder).SQuote()} already has the fields " +
          $"{_fields.Aggregate("", (s, i) => s += i.ToString().ToLower()).Quote()}.");

      _fields = fields;
      return this;
    }

    ArchiveQueryBuilder IArchiveQueryBuilder.WithSort(
      ArchiveQueryField sortField,
      SortDirection sortDirection)
    {
      if (_sortField != null)
        throw new InvalidOperationException(
          $"The sortField cannot be set to {sortField.ToString().ToLower().Quote()} because the " +
          $"instance of {nameof(ArchiveQueryBuilder).SQuote()} already has the sortField " +
          $"{_sortField.ToString().ToLower().SQuote()}.");

      _sortField = sortField;

      if (_sortDirection != null)
        throw new InvalidOperationException(
          $"The sortDirection cannot be set to {sortDirection.ToString().ToLower().Quote()} because the " +
          $"instance of {nameof(ArchiveQueryBuilder).SQuote()} already has the sortDirection " +
          $"{_sortDirection.ToString().ToLower().SQuote()}.");

      _sortDirection = sortDirection;

      return this;
    }

    ArchiveQueryBuilder IArchiveQueryBuilder.WithRows(
      uint rowCount)
    {
      if (_rowCount != null)
        throw new InvalidOperationException(
          $"The rowCount cannot be set to {rowCount.ToString().SQuote()} because the instance of " +
          $"{nameof(ArchiveQueryBuilder).SQuote()} already has the rowCount " +
          $"{_rowCount.ToString().Quote()}.");

      _rowCount = rowCount;
      return this;
    }

    ArchiveQueryBuilder IArchiveQueryBuilder.OnPageNumber(
      uint pageNumber)
    {
      if (_onPageNumber != null)
        throw new InvalidOperationException(
          $"The pageNumber cannot be set to {pageNumber.ToString().SQuote()} because the instance of " +
          $"{nameof(ArchiveQueryBuilder).SQuote()} already has the pageNumber " +
          $"{_onPageNumber.ToString().Quote()}.");

      _onPageNumber = pageNumber;
      return this;
    }

    ArchiveQueryBuilder IArchiveQueryBuilder.WithOutputKind(
      APIDataOutputKind dataOutputKind)
    {
      if (_dataOutputKind != null)
        throw new InvalidOperationException(
          $"The dataOutputKind cannot be set to {dataOutputKind.ToString().ToLower().SQuote()} " +
          $"because the instance of {nameof(ArchiveQueryBuilder).SQuote()} already has the " +
          $"dataOutputKind {_dataOutputKind.ToString().ToLower().SQuote()}.");

      _dataOutputKind = dataOutputKind;
      return this;
    }

    ArchiveQueryBuilder IArchiveQueryBuilder.WithCallback(
      string callback)
    {
      if (_callback != null)
        throw new InvalidOperationException(
          $"The callback cannot be set to {callback.Quote()} because the instance of " +
          $"{nameof(ArchiveQueryBuilder).SQuote()} already has the callback {_callback.Quote()}.");

      _callback = callback;
      return this;
    }

    ArchiveQueryBuilder IArchiveQueryBuilder.WithShouldSave(
      bool shouldSave)
    {
      if (_shouldSave != null)
        throw new InvalidOperationException(
          $"The shouldSave cannot be set to {shouldSave.ToString().SQuote()} because the instance of " +
          $"{nameof(ArchiveQueryBuilder).SQuote()} already has the shouldSave " +
          $"{_shouldSave.ToString().Quote()}.");

      _shouldSave = shouldSave;
      return this;
    }


    public string BuilldRequestUrl(
      DomainFragment requestBuilder)
    {
      var uriBuilder = requestBuilder
        .Builder
        .WithPath("advancedsearch.php");

      void _setQueryString(
        string uploader,
        string subject)
      {
        var sb = new StringBuilder();

        if (uploader != null)
        {
          sb.Append($"uploader:{uploader}");

          if (subject != null)
          {
            sb.Append($" AND ");
            sb.Append($"subject:({subject})");
          }
        }
        else
        {
          if (subject != null)
          {
            sb.Append($"subject:({subject})");
          }
        }

        uriBuilder
          .WithParameter(
            "q",
            sb.ToString());
      }

      _setQueryString(
        _uploader,
        _subject);

      if (_fields != null)
      {
        foreach (var field in _fields)
        {
          uriBuilder.WithParameter("fl[]", field.ToString().ToLower());
        }
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

      if (_rowCount.HasValue)
      {
        uriBuilder.WithParameter("rows", _rowCount.ToString());
      }

      if (_onPageNumber.HasValue)
      {
        uriBuilder.WithParameter("page", _onPageNumber.ToString());
      }

      if (_dataOutputKind.HasValue)
      {
        uriBuilder.WithParameter("output", _dataOutputKind.ToString().ToLower());
      }

      if (_callback != null)
      {
        uriBuilder.WithParameter("callback", _callback);
      }

      if (_shouldSave.HasValue)
      {
        uriBuilder.WithParameter("save", _shouldSave.Value ? "yes" : "no");
      }

      return uriBuilder.Build();
    }
  }
}
