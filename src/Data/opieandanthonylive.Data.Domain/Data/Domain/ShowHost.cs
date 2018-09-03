using Ccr.Dnc.Core.Extensions;
using JetBrains.Annotations;

namespace opieandanthonylive.Data.Domain
{
  //[EntityConfigurator(typeof(ShowHostMap))]
  public partial class ShowHost
  {
    public int ShowHostID { get; set; }

    public int ShowID { get; set; }
    public virtual Show Show { get; set; }

    public int HostID { get; set; }
    public virtual Host Host { get; set; }



    public ShowHost()
    {
    }

    public ShowHost(
      [NotNull] Show show,
      [NotNull] Host host) : this()
    {
      show.IsNotNull(nameof(show));
      host.IsNotNull(nameof(host));

      Show = show;
      Host = host;
    }
    
    private ShowHost(
      int showHostID,
      [NotNull] Show show,
      [NotNull] Host host) : this(
        show,
        host)
    {
      ShowHostID = showHostID;
    }
  }
}