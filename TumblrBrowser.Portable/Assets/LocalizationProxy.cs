namespace TumblrBrowser.Portable.Assets
{
  /// <summary>
  /// Proxy to localization resources for XAML bindings
  /// </summary>
  public class LocalizationProxy
  {
    public Localization Localization => localization;

    private static readonly Localization localization = new Localization( );
  }
}