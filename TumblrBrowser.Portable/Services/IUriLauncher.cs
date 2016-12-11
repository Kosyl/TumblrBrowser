namespace TumblrBrowser.Portable.Services
{
  /// <summary>
  /// Interface for launching other applications based on the URL provided
  /// </summary>
  public interface IUriLauncher
  {
    void LaunchUri( string url );
  }
}
