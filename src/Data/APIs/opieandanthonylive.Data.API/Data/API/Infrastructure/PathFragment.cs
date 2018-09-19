using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opieandanthonylive.Data.API.Infrastructure
{
  public class PathFragment
    : IPathFragment
  {
    private string _path;
    public string Path
    {
      get => _path;
      set => _path = value.Trim(' ', '/', '\\');
    }

    public PathFragment(
      string path)
    {
      Path = path;
    }
    public string GetFragment(bool start, bool end)
    {
      var fragment = Path;
      if (start)
      {
        fragment = $"/{fragment}";
      }
      if (end)
      {
        fragment = $"{fragment}/";
      }
      return fragment;
    }
  }
}
