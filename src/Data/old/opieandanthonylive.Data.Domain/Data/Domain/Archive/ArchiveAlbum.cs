using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Ccr.Dnc.Core.Extensions;
using Ccr.Dnc.Data.EntityFrameworkCore.Infrastucture;
using JetBrains.Annotations;

namespace opieandanthonylive.Data.Domain.Archive
{
  public class ArchiveAlbum
    : EntityBase
  {
    [NotMapped]
    private readonly Func<ArchiveAlbum, IEnumerable<ArchiveFile>> _archiveAlbumFilesScraper;
    [NotMapped]
    private ArchiveFile[] _archiveFiles;

    
    public int ArchiveAlbumID { get; set; }

    [NotNull]
    public string Identifier { get; set; }

    public int? ContentCreatorID { get; set; }
    [CanBeNull, ForeignKey("ContentCreatorID")]
    public virtual ContentCreator ContentCreator { get; set; }

    public string Description { get; set; }

    public DateTime DatePublished { get; set; }

    public int YearNumber { get; set; }

    public int MonthNumber { get; set; }

    [NotMapped]
    public string AlbumFileContentsUrl
    {
      get => $"https://www.archive.org/download/{Identifier}/";
    }

    public virtual ICollection<ArchiveFile> ArchiveFiles
    {
      get => _archiveFiles
             ?? (_archiveFiles = _archiveAlbumFilesScraper(this).ToArray());
    }

    private ArchiveAlbum()
    {
    }

    public ArchiveAlbum(
      [NotNull] string identifier,
      [CanBeNull] ContentCreator contentCreator,
      string description,
      DateTime datePublished,
      int yearNumber,
      int monthNumber,
      Func<ArchiveAlbum, IEnumerable<ArchiveFile>> archiveAlbumFilesScraper)
        : this()
    {
      identifier.IsNotNull(nameof(identifier));

      Identifier = identifier;
      ContentCreator = contentCreator;
      Description = description;
      DatePublished = datePublished;
      YearNumber = yearNumber;
      MonthNumber = monthNumber;
      _archiveAlbumFilesScraper = archiveAlbumFilesScraper;
    }

  }
}
