using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace opieandanthonylive.Data.API.Infrastructure
{
  public class UrlBuilder
  {
    private readonly DomainFragment _domainFragment;

    private readonly List<IPathFragment> _pathFragments
      = new List<IPathFragment>();

    private readonly List<IQueryParameterAssignment> _parameterFragments
      = new List<IQueryParameterAssignment>();

    private readonly List<INamedAnchorFragment> _namedArchorFragments
      = new List<INamedAnchorFragment>();



    public UrlBuilder(
      DomainFragment domainFragment)
    {
      _domainFragment = domainFragment;
    }

    public UrlBuilder WithPath(
      string path)
    {
      _pathFragments.Add(
        new PathFragment(
          path));
      return this;
    }

    public UrlBuilder WithParameter(
      string parameterName,
      string argument)
    {
      _parameterFragments.Add(
        new QueryParameterAssignment(
          parameterName,
          argument));
      return this;
    }

    public UrlBuilder WithAnchor(
      string anchorValue)
    {
      _namedArchorFragments.Add(
        new NamedAnchorFragment(anchorValue));
      return this;
    }

    public string Build()
    {
      var sb = new StringBuilder();

      sb.Append(_domainFragment.GetFragment(false, true));

      var pathFragments = _pathFragments.Count;
      var pathFragmentIndex = 0;
      foreach (var pathFragment in _pathFragments)
      {
        var currentFragment = "";

        if (pathFragmentIndex == pathFragments - 1)
        {
          currentFragment = pathFragment.GetFragment(false, false);
        }
        else if (pathFragmentIndex == 0)
        {
          currentFragment = pathFragment.GetFragment(false, true);
        }
        else
        {
          currentFragment = pathFragment.GetFragment(false, true);
        }

        sb.Append(currentFragment);
      }

      var parameterStr = buildParameters();
      sb.Append(parameterStr);

      foreach (var namedArchorFragment in _namedArchorFragments)
      {
        sb.Append(namedArchorFragment.GetFragment(true, false));
      }

      return sb.ToString();
    }

    private string buildParameters()
    {
      if (!_parameterFragments.Any())
        return "";

      var paramStr = "?";
      foreach (var parameterFragment in _parameterFragments)
      {
        var currentFragment = parameterFragment.GetFragment(false, true);
        paramStr += currentFragment;
      }

      return paramStr.TrimEnd('&');
    }
  }
}