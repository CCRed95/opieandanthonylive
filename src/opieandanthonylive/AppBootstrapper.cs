using System.Collections.Generic;
using System.Windows;
using Caliburn.Micro;
using opieandanthonylive.ViewModels;

namespace opieandanthonylive
{
  public class AppBootstrapper
    : BootstrapperBase
  {
    public AppBootstrapper()
    {
      Initialize();
    }

    protected override void OnStartup(object sender, StartupEventArgs e)
    {
      var settings = new Dictionary<string, object>
      {
        { "SizeToContent", SizeToContent.Manual },
        { "WindowState" , WindowState.Maximized }
      };

      DisplayRootViewFor<RootViewModel>(settings);
    }
  }
}
