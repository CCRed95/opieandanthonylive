using Ccr.Data.EntityFrameworkCore;
using Ccr.Data.EntityFrameworkCore.Infrastucture;

namespace opieandanthonylive.Data.Domain
{
  public partial class GuestAppearanceType
    : EntityBase,
      ISeedableEntity
  {
    public static GuestAppearanceType Studio_Appearance
      = new GuestAppearanceType(1);

    public static GuestAppearanceType Phone_Appearance
      = new GuestAppearanceType(2);
  }
}