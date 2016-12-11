using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WinRTXamlToolkit.Interactivity;

namespace TumblrBrowser.Behaviors
{
  /// <summary>
  /// Binding to a string containing the HTML to show in a WebView
  /// </summary>
  public class WebViewHtmlBinding: Behavior<WebView>
  {
    public static readonly DependencyProperty HtmlStringProperty = DependencyProperty.Register(
      "HtmlString", typeof( string ), typeof( WebViewHtmlBinding ), new PropertyMetadata( default(string), HtmlStringChanged ) );

    private static void HtmlStringChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
    {
      var self = d as WebViewHtmlBinding;
      self.NavigateWebViewTo( e.NewValue as string );
    }

    private void NavigateWebViewTo( string html )
    {
      if( !String.IsNullOrWhiteSpace( html ) )
      {
        //function getHeight enables stretching WebView control to the size of loaded content

        var htmlScript = "<script type=\"text/javascript\">"
                         + "function getHeight()  {"
                         + "return document.getElementById(\"wrapper\").offsetHeight.toString(); }; </script>";


        var htmlConcat = "<html><head></head>" + "<body  style=\"margin:0;padding:0;font-size: 100%\" " + ">" + "<div id=\"wrapper\" style=\"width:100%;" + $"\">{html}</div></body>{htmlScript}</html>";

        this.AssociatedObject?.NavigateToString( htmlConcat );
      }
    }

    public string HtmlString
    {
      get
      {
        return (string) this.GetValue( HtmlStringProperty );
      }
      set
      {
        this.SetValue( HtmlStringProperty, value );
      }
    }

    protected override void OnAttached( )
    {
      base.OnAttached( );
      this.AssociatedObject.NavigationCompleted += this.AssociatedObject_NavigationCompleted;
      this.NavigateWebViewTo( this.HtmlString );
    }

    private async void AssociatedObject_NavigationCompleted( WebView sender, WebViewNavigationCompletedEventArgs args )
    {
      string contentHeight = await this.AssociatedObject.InvokeScriptAsync( "getHeight", null );
      this.AssociatedObject.Height = Math.Max( int.Parse( contentHeight ), 40 );
    }

    protected override void OnDetaching( )
    {
      this.AssociatedObject.NavigationCompleted -= this.AssociatedObject_NavigationCompleted;
      base.OnDetaching( );
    }
  }
}