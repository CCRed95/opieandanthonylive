using Ccr.Data.EntityFrameworkCore;

namespace opieandanthonylive.Data.Domain
{
  public partial class Show
    : ISeedableEntity
  {
    public static Show OpieAndAnthonyShow = new Show(
      1,
      "Opie and Anthony",
      Host.Gregg_Hughes,
      Host.Anthony_Cumia,
      Host.Jim_Norton);

    public static Show RonAndFezShow = new Show(
      2,
      "Ron and Fez",
      Host.Ron_Bennington,
      Host.Fez_Whatley);

    public static Show RickyGervaisShowXFM = new Show(
      3,
      "Ricky Gervais Show XFM",
      Host.Ricky_Gervais,
      Host.Stephen_Merchant,
      Host.Karl_Pilkington);

    public static Show RickyGervaisShowPodcasts = new Show(
      4,
      "Ricky Gervais Show Podcasts",
      Host.Ricky_Gervais,
      Host.Stephen_Merchant,
      Host.Karl_Pilkington);

    public static Show RickyGervaisShowHBO = new Show(
      5,
      "Ricky Gervais Show HBO",
      Host.Ricky_Gervais,
      Host.Stephen_Merchant,
      Host.Karl_Pilkington);

    public static Show ToughCrowdWithColinQuinn = new Show(
      6,
      "Tough Crowd with Colin Quinn",
      Host.Colin_Quinn);

    public static Show Cumtown = new Show(
      7,
      "Cumtown",
      Host.Nick_Mullen,
      Host.Stavros_Halkias,
      Host.Adam_Friedland);
  }
}