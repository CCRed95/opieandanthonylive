using Ccr.Dnc.Data.EntityFrameworkCore;

namespace opieandanthonylive.Data.Domain
{
  public partial class ShowRundownAuthor
    : ISeedableEntity
  {
    public static ShowRundownAuthor Unknown
      = new ShowRundownAuthor(01);

    public static ShowRundownAuthor Melinda
      = new ShowRundownAuthor(02);

    public static ShowRundownAuthor Struff
      = new ShowRundownAuthor(03);

    public static ShowRundownAuthor Happy_Typing_Girl
      = new ShowRundownAuthor(04);

    public static ShowRundownAuthor Audible
      = new ShowRundownAuthor(05);

    public static ShowRundownAuthor CCRed95
      = new ShowRundownAuthor(06);
  }
}