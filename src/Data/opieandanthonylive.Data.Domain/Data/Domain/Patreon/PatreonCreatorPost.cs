using System;

namespace opieandanthonylive.Data.Domain.Patreon
{
  public class PatreonCreatorPost
  {
    public int PatreonCreatorPostID { get; set; }

    public DateTime PostDateTime { get; set; }

    public string PostTitle { get; set; }

    public string PostBody { get; set; }
  }
}
