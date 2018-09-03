using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using opieandanthonylive.Data.Domain.Complex;

namespace opieandanthonylive.Data.Domain
{
  public partial class Guest
    : Person
  {
    public int GuestID { get; set; }

    public int? LegacyGuestID { get; set; }

    public string Description { get; set; }

    public string TwitterHandle { get; set; }

    public string WebsiteUrl { get; set; }

    public string HeadshotImagePath { get; set; }


    public virtual ICollection<GuestAppearance> ShowAppearances { get; set; }


    [UsedImplicitly]
    public Guest()
    {
      ShowAppearances = new HashSet<GuestAppearance>();
    }

    public Guest(
      [NotNull] string fullName)
        : this()
    {
      FullName = fullName;
    }

    public Guest(
      [NotNull] string fullName,
      [NotNull] Gender gender)
        : this(
          fullName)
    {
       Gender = gender;
    }

    public Guest(
      [NotNull] string fullName,
      [NotNull] Gender gender,
      [CanBeNull] int? legacyGuestID,
      [CanBeNull] string description,
      [CanBeNull] string twitterHandle,
      [CanBeNull] string websiteUrl,
      [CanBeNull] string headshotImagePath)
        : this(
          fullName,
          gender)
    {
      LegacyGuestID = legacyGuestID;
      Description = description;
      TwitterHandle = twitterHandle;
      WebsiteUrl = websiteUrl;
      HeadshotImagePath = headshotImagePath;
    }

    private Guest(
      int guestID,
      [NotNull] string fullName,
      [NotNull] Gender gender) : this(
        fullName,
        gender)
    {
      GuestID = guestID;
    }


    public static Guest Define(
      int legacyID,
      [CallerLineNumber] int callerLineNumber = 0,
      [CallerMemberName] string callerMemberName = "")
    {
      var guest = PersonFactory.CreatePerson<Guest>(
        callerMemberName);

      guest.LegacyGuestID = legacyID;

      return guest;
    }
  }
}