using System;
using Windows.UI.Xaml.Data;

namespace TumblrBrowser.Converters
{
  /// <summary>
  /// Converter choosing an icon based on the post type
  /// </summary>
  public class PostTypeToImageSourceConverter : IValueConverter
  {
    private const string ImagePathFormat = "ms-appx:///Assets/Icons/{0}.png";

    public object Convert( object value, Type targetType, object parameter, string language )
    {
      var str = value as string;

      if(!String.IsNullOrEmpty(str))
        return String.Format(ImagePathFormat, str);

      return null;
    }

    public object ConvertBack( object value, Type targetType, object parameter, string language )
    {
      return null;
    }
  }
}
