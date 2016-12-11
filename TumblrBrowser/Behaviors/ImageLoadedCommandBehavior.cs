using System;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WinRTXamlToolkit.Interactivity;

namespace TumblrBrowser.Behaviors
{
  /// <summary>
  /// This behavior, when attached to an Image control, will launch the provided command when the image loads successfully.
  /// </summary>
  public class ImageLoadedCommandBehavior : Behavior<Image>
  {
    public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
      "Command", typeof( ICommand ), typeof( ImageLoadedCommandBehavior ), new PropertyMetadata( default(ICommand) ) );

    public ICommand Command
    {
      get
      {
        return (ICommand) GetValue( CommandProperty );
      }
      set
      {
        SetValue( CommandProperty, value );
      }
    }

    protected override void OnAttached( )
    {
      base.OnAttached( );
      this.AssociatedObject.ImageOpened += AssociatedObject_ImageOpened;
    }

    private void AssociatedObject_ImageOpened( object sender, RoutedEventArgs e )
    {
      this.Command?.Execute(null);
    }
    
    protected override void OnDetaching( )
    {
      this.AssociatedObject.ImageOpened -= AssociatedObject_ImageOpened;
      base.OnDetaching( );
    }
  }
}