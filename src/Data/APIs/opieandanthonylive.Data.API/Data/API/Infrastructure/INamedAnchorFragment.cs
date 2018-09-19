namespace opieandanthonylive.Data.API.Infrastructure
{
  public interface INamedAnchorFragment
    : IUriFragment
  {
    string AnchorValue { get; }
  }
}
