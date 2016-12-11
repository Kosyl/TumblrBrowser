using System;
using TumblrBrowser.Portable.Services;

namespace TumblrBrowser.Services
{
  /// <summary>
  /// Universal launcher for various protocols (mainly HTTP/HTTPS)
  /// </summary>
  public class UriLauncher: IUriLauncher
  {
    public void LaunchUri( string url )
    {
      Windows.System.Launcher.LaunchUriAsync( new Uri(url) );
    }
  }
}
