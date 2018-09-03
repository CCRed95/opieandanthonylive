using Ccr.Dnc.Data.EntityFrameworkCore;

namespace opieandanthonylive.Data.Domain.Archive
{
  public partial class ContentCreator
    : ISeedableEntity
  {
    public static readonly ContentCreator Opie_and_Anthony
      = new ContentCreator(1);

    public static readonly ContentCreator Ron_and_Fez
      = new ContentCreator(2);

    public static readonly ContentCreator Ricky_Gervais
      = new ContentCreator(3);
  }
}
