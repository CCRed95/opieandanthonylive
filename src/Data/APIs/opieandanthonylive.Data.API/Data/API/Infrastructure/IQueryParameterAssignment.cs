using opieandanthonylive.Data.API.Infrastructure;

namespace opieandanthonylive.Data.API.Infrastructure
{
  public interface IQueryParameterAssignment
    : IUriFragment
  {
    string ParameterName { get; }

    string ArgumentValue { get; }
  }
}