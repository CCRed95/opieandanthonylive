using System.Collections.Generic;
using opieandanthonylive.Data.Domain;

namespace opieandanthonylive.Data.API.Rundowns.DataSources
{
  public class RundownDataSources
  {
    public static RundownDataSource MelindaRundowns
      = new RundownDataSource(
        ShowRundownAuthor.Melinda, 
        "61-Mellinda-s-Old-O-amp-A-Rundowns");

    public static RundownDataSource HappyTypingGirlRundowns
      = new RundownDataSource(
        ShowRundownAuthor.Happy_Typing_Girl,
        "44-Happytypinggirl-s-old-Rundowns-amp-Recaps");

    public static RundownDataSource StruffRundowns
      = new RundownDataSource(
        ShowRundownAuthor.Struff,
        "49-Struff-s-old-Recaps-amp-Rundowns");



    public static IEnumerable<RundownDataSource> RundownDataSourceList
    {
      get => new[]
      {
        MelindaRundowns,
        HappyTypingGirlRundowns,
        StruffRundowns
      };
    }
  }
}