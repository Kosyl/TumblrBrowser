using System;
using Windows.UI.Xaml.Data;

namespace TumblrBrowser.Converters
{
  /// <summary>
  /// Converter from a string containing the URL of an image into an Uri object
  /// </summary>
  public class StringToImageSourceConverter : IValueConverter
  {
    public object Convert( object value, Type targetType, object parameter, string language )
    {
      var str = value as string;

      if(!String.IsNullOrEmpty(str) && Uri.IsWellFormedUriString( str, UriKind.Absolute ))
        return new Uri( str );

      return null;
    }

    public object ConvertBack( object value, Type targetType, object parameter, string language )
    {
      return null;
    }
  }
}
