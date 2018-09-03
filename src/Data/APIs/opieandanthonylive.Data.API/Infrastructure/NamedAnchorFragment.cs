namespace opieandanthonylive.Data.API.Infrastructure
{
  public class NamedAnchorFragment
    : INamedAnchorFragment
  {
    public string AnchorValue { get; }
    

    public string GetFragment(bool start, bool end)
    {
      var fragment = AnchorValue;
      if (start)
      {
        fragment = $"#{fragment}";
      }
      if (end)
      {
      }
      return fragment;
    }


    public NamedAnchorFragment(
      string anchorValue)
    {
      AnchorValue = anchorValue;
    }
  }
}