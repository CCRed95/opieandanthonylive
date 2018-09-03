using System.ComponentModel.DataAnnotations.Schema;
using Ccr.Dnc.Core.Extensions;
using JetBrains.Annotations;

namespace opieandanthonylive.Data.Domain
{
	public class GuestAppearance
	{
		public int GuestAppearanceID { get; set; }

    public int? GuestID { get; set; }
    [NotNull, ForeignKey("GuestID")]
    public virtual Guest Guest { get; set; }


    public int? ShowMediaEntryID { get; set; }
	  [NotNull, ForeignKey("ShowMediaEntryID")]
	  public virtual ShowMediaEntry ShowMediaEntry { get; set; }


	  public long? SegmentTimeStart { get; set; }

	  public long? SegmentTimeEnd { get; set; }

    
    private GuestAppearance() { }

		public GuestAppearance(
			[NotNull] Guest guest,
			[NotNull] ShowMediaEntry showMediaEntry) 
		    : this()
		{
      guest.IsNotNull(nameof(guest));
      showMediaEntry.IsNotNull(nameof(showMediaEntry));

			Guest = guest;
		  ShowMediaEntry = showMediaEntry;
		}

	  public GuestAppearance(
	    [NotNull] Guest guest,
	    [NotNull] ShowMediaEntry showMediaEntry,
      long? segmentStartTime,
      long? segmentTimeEnd)
	      : this(
          guest,
          showMediaEntry)
	  {
	    SegmentTimeEnd = segmentTimeEnd;
	    SegmentTimeStart = segmentStartTime;
    }

	  protected GuestAppearance(
			int guestAppearanceID,
			[NotNull] Guest guest,
			[NotNull] ShowMediaEntry showRundown,
	    long? segmentStartTime,
	    long? segmentTimeEnd)
	      : this(
				  guest,
				  showRundown,
          segmentStartTime,
          segmentTimeEnd)
		{
			GuestAppearanceID = guestAppearanceID;
		}
	}
}
