using System.ComponentModel.DataAnnotations.Schema;

namespace Ccr.Dnc.Data.EntityFrameworkCore.Infrastucture
{
  public class EntityBase
  {
    [NotMapped]
    private int? _entityID;

    [NotMapped]
    public int? EntityID
    {
      get => _entityID;
      internal set
      {
        _entityID = value;
      }
    }


  }
}
