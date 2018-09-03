using System.Collections.Generic;
using Ccr.Dnc.Core.Extensions;
using JetBrains.Annotations;
using opieandanthonylive.Data.Domain.Complex;

namespace opieandanthonylive.Data.Domain
{
  //[EntityConfigurator(typeof(HostMap))]
  public partial class Host
    : Person
  {
    public int HostID { get; set; }
    
    public string Description { get; set; }

    public string TwitterHandle { get; set; }

    public string WebsiteUrl { get; set; }

    public string HeadshotImagePath { get; set; }


    public virtual ICollection<ShowHost> ShowHosts { get; set; }



    public Host()
    {
    }

    public Host(
      [NotNull] string fullName,
      [NotNull] string firstName,
      [NotNull] string lastName,
      [NotNull] Gender gender) : this()
    {
      fullName.IsNotNull(nameof(fullName));
      firstName.IsNotNull(nameof(firstName));
      lastName.IsNotNull(nameof(lastName));
      gender.IsNotNull(nameof(gender));

      FullName = fullName;
      FirstName = firstName;
      LastName = lastName;
      GenderID = gender.GenderID;
    }

    public Host(
      [NotNull] string fullName,
      [NotNull] string firstName,
      [CanBeNull] string middleName,
      [NotNull] string lastName,
      [NotNull] Gender gender,
      [CanBeNull] string alternateName,
      [CanBeNull] string description,
      [CanBeNull] string twitterHandle,
      [CanBeNull] string websiteUrl,
      [CanBeNull] string headShotImagePath) : this(
        fullName,
        firstName,
        lastName,
        gender)
    {
      MiddleName = middleName;
      AlternateName = alternateName;
      Description = description;
      TwitterHandle = twitterHandle;
      WebsiteUrl = websiteUrl;
      HeadshotImagePath = headShotImagePath;
    }

    private Host(
      int hostID,
      [NotNull] string fullName,
      [NotNull] string firstName,
      [CanBeNull] string middleName,
      [NotNull] string lastName,
      [NotNull] Gender gender,
      [CanBeNull] string alternateName,
      [CanBeNull] string description,
      [CanBeNull] string twitterHandle,
      [CanBeNull] string websiteUrl,
      [CanBeNull] string headShotImagePath) : this(
        fullName,
        firstName,
        middleName,
        lastName,
        gender,
        alternateName,
        description,
        twitterHandle,
        websiteUrl,
        headShotImagePath)
    {
      HostID = hostID;
    }
  }
}
