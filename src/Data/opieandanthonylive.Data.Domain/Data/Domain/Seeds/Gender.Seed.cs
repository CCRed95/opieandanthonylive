using Ccr.Data.EntityFrameworkCore;
using Ccr.Data.EntityFrameworkCore.Infrastucture;

namespace opieandanthonylive.Data.Domain
{
  public partial class Gender
    : EntityBase,
      ISeedableEntity
  {
    public static readonly Gender Unset 
	    = new Gender("U", "Unset");

    public static readonly Gender Male
	    = new Gender("M", "Male");

    public static readonly Gender Female 
	    = new Gender("F", "Female");
  }
}