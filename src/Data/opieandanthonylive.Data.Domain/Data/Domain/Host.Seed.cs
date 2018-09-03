using System.Runtime.CompilerServices;
using Ccr.Dnc.Data.EntityFrameworkCore;
using JetBrains.Annotations;
using opieandanthonylive.Data.Domain.Complex;

namespace opieandanthonylive.Data.Domain
{
  public partial class Host
    : ISeedableEntity
  {
    [UsedImplicitly]
    private class HostFactory
    {
      public static Host Create(
        Gender gender = null,
        string twitterHandle = null,
        string websiteUrl = null,
        [CallerLineNumber] int callerLineNumber = 0,
        [CallerMemberName] string callerMemberName = "")
      {
        var entity = EntityFactory.CreateImpl<Host>(
          callerLineNumber,
          callerMemberName);

        entity.Gender = gender;
        entity.TwitterHandle = twitterHandle;
        entity.WebsiteUrl = websiteUrl;

        return entity;
      }
    }


    public static Host Gregg_Hughes = HostFactory.Create(
      Gender.Male,
      "@opieradio");

    public static Host Anthony_Cumia = HostFactory.Create(
      Gender.Male,
      "@AnthonyCumiaxyz",
      "https://www.compoundmedia.com/");

    public static Host Jim_Norton = HostFactory.Create(
      Gender.Male,
      "@JimNorton",
      "http://jimnorton.com/");

    public static Host Ron_Bennington = HostFactory.Create(
      Gender.Male,
      "@BenningtonShow",
      "http://theronandfezshow.com/");

    public static Host Fez_Whatley = HostFactory.Create(
      Gender.Male,
      "@Fezshitter",
      "http://theronandfezshow.com/");

    public static Host Ricky_Gervais = HostFactory.Create(
      Gender.Male,
      "@rickygervais",
      "http://rickygervais.com/");

    public static Host Stephen_Merchant = HostFactory.Create(
      Gender.Male,
      "@stephenmerchant",
      "http://stephenmerchant.com/");

    public static Host Karl_Pilkington = HostFactory.Create(
      Gender.Male,
      "@karlpilkington");

    public static Host Colin_Quinn = HostFactory.Create(
      Gender.Male,
      "@@iamcolinquinn");
  }
}