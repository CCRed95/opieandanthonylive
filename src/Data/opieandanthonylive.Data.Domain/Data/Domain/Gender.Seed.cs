using Ccr.Dnc.Data.EntityFrameworkCore;
using opieandanthonylive.Data.Domain.Complex;
using Ccr.Dnc.Data.EntityFrameworkCore.Infrastucture;

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