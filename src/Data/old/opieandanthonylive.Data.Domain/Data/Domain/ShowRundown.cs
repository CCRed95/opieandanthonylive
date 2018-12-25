using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;
using opieandanthonylive.Data.Domain.Archive;

// ReSharper disable VirtualMemberCallInConstructor
namespace opieandanthonylive.Data.Domain
{
  public class ShowRundown
  {
    public int ShowRundownID { get; set; }

    public string ShowRundownName { get; set; }

    public string ShowRundownContent { get; set; }


    public int? ArchiveFileID { get; set; }
    [CanBeNull, ForeignKey("ArchiveFileID")]
    public virtual ArchiveFile ArchiveFile { get; set; }

    
    public int? ShowRundownAuthorID { get; set; }
    [CanBeNull, ForeignKey("ShowRundownAuthorID")]
    public virtual ShowRundownAuthor ShowRundownAuthor { get; set; }


    public DateTime AirDate { get; set; }

    public string DetailsUrl { get; set; }
    

    public virtual ICollection<GuestAppearance> GuestAppearances { get; set; }

    
    private ShowRundown()
    {
      GuestAppearances = new HashSet<GuestAppearance>();
    }

    public ShowRundown(
      [NotNull] string showRundownName,
      [CanBeNull] string showRundownContent,
      [NotNull] ArchiveFile archiveFile,
      [NotNull] ShowRundownAuthor showRundownAuthor,
      DateTime airDate,
      [NotNull] string detailsUrl) 
        : this()
    {
      ShowRundownName = showRundownName;
      ShowRundownContent = showRundownContent;
      ArchiveFile = archiveFile;
      ShowRundownAuthor = showRundownAuthor;
      AirDate = airDate;
      DetailsUrl = detailsUrl;
    }

    private ShowRundown(
      int showRundownID,
      [NotNull] string showRundownName,
      [CanBeNull] string showRundownContent,
      [NotNull] ArchiveFile archiveFile,
      [NotNull] ShowRundownAuthor showRundownAuthor,
      DateTime airDate,
      [NotNull] string detailsUrl)
        : this(
          showRundownName,
          showRundownContent,
          archiveFile,
          showRundownAuthor,
          airDate,
          detailsUrl)
    {
      ShowRundownID = showRundownID;
    }
  }
}
/*
 *TODO REGEX (?<k>\b\d{1,2}\D{0,3})?\b(?:Jan(?:uary)?|Feb(?:ruary)?|Mar(?:ch)?|Apr(?:il)?|May|Jun(?:e)?|Jul(?:y)?|Aug(?:ust)?|Sep(?:tember)?|Oct(?:ober)?|(Nov|Dec)(?:ember)?)\D?(\d{1,2}\D?)?\D?(?<year>(19[7-9]\d|20\d{2})|\d{2})

\A(January|February|March|April|May|June|July|August|Septmber|October|November|December)


\A(?<month>January|February|March|April|May|June|July|August|Septmber|October|November|December) (?<day>[0-9]{1,2}), (?<year>200[0-9])

\A(?<month>January|February|March|April|May|June|July|August|September|October|November|December) (?<day>[0-9]{1,2}), (?<year>200[0-9]) ?(?<dayOfWeek>(?:Mon|Tues|Wednes|Thurs|Fri|Satur|Sun)day)?-?[\s]*([^:|;|,|!]*)

\s?\([0-9] replies\)
 
	 
	 
	 */
