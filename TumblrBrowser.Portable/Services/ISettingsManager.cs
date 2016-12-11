namespace TumblrBrowser.Portable.Services
{
  /// <summary>
  /// Service to manage isolated storage settings, e.g. saving username between app launches
  /// </summary>
  public interface ISettingsManager
  {
    string Get( string key );
    void Set( string key, string value );
  }
}
