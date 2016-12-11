using TumblrBrowser.Portable.Services;

namespace TumblrBrowser.Services
{
  /// <summary>
  /// Manager that stores settings in the local application folder
  /// </summary>
  public class SettingsManager: ISettingsManager
  {
    public string Get( string key )
    {
      var settings = Windows.Storage.ApplicationData.Current.LocalSettings;
      if( settings.Values.ContainsKey( key ) )
      {
        return settings.Values[ key ] as string;
      }
      else
      {
        return null;
      }
    }

    public void Set( string key, string value )
    {
      var settings = Windows.Storage.ApplicationData.Current.LocalSettings;
      settings.Values[ key ] = value;
    }
  }
}
