using Ccr.Data.EntityFrameworkCore;
using Ccr.Data.EntityFrameworkCore.Infrastucture;
using opieandanthonylive.Data.Domain.Complex;

namespace opieandanthonylive.Data.Domain
{
  public partial class Gender
    : EntityBase,
      ISeedableEntity
  {
    public static Gender Unset
      = EntityFactory.Create<Gender>();

    public static Gender Male
      = EntityFactory.Create<Gender>();

    public static Gender Female
      = EntityFactory.Create<Gender>();
  }
}