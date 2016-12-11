using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace TumblrBrowser.Converters
{
  /// <summary>
  /// Universal converter for resolving Visibility based on various object types
  /// </summary>
  public class ValueToVisibilityConverter: IValueConverter
  {
    /// <summary>
    /// Converter from an object into System.Visibility.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="targetType"></param>
    /// <param name="parameter">If passed string "Reversed", a non-null or equivalent object will convert to Visibility.Collapsed, and null or equivalent - to Visibility.Visible.</param>
    /// <param name="language"></param>
    /// <returns></returns>
    public object Convert( object value, Type targetType, object parameter, string language )
    {
      Visibility positive = Visibility.Visible;
      Visibility negative = Visibility.Collapsed;

      if( string.Equals( parameter as string, "reversed", StringComparison.OrdinalIgnoreCase ) )
      {
        positive = Visibility.Collapsed;
        negative = Visibility.Visible;
      }

      if( value is string )
      {
        return !String.IsNullOrEmpty( value as string ) ? positive : negative;
      }

      if( value is int )
      {
        return (int)value != 0 ? positive : negative;
      }

      if( value is bool )
      {
        return (bool)value ? positive : negative;
      }

      return value != null ? positive : negative;
    }

    public object ConvertBack( object value, Type targetType, object parameter, string language )
    {
      return null;
    }
  }
}
