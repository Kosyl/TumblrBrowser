using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using WinRTXamlToolkit.Interactivity;

namespace TumblrBrowser.Behaviors
{
  /// <summary>
  /// A behavior for launching a command when user scrolls to the bottom of the list control.
  /// </summary>
  public class IncrementalLoadingBehavior: Behavior<ListView>
  {
    public static readonly DependencyProperty LoadMoreObjectsCommandProperty = DependencyProperty.Register(
      "LoadMoreObjectsCommand", typeof( ICommand ), typeof( IncrementalLoadingBehavior ), new PropertyMetadata( default(ICommand) ) );

    public ICommand LoadMoreObjectsCommand
    {
      get
      {
        return (ICommand) GetValue( LoadMoreObjectsCommandProperty );
      }
      set
      {
        SetValue( LoadMoreObjectsCommandProperty, value );
      }
    }

    //Margin preventing the command from launching multiple times
    private const int Threshold = 50; //pixels
    private bool atEnd;
    private ScrollViewer scroll;

    protected override void OnAttached( )
    {
      base.OnAttached( );

      this.atEnd = false;

      this.scroll = GetScrollViewer( this.AssociatedObject );
      if( this.scroll != null )
      {
        this.scroll.ViewChanged += this.scrollViewChanged;
      }
      else // ListView hasn't loaded yet
      {
        this.AssociatedObject.Loaded += AssociatedObject_Loaded;
      }
    }

    /// <summary>
    /// Deferred scroll handler attaching 
    /// for situations when the behavior is attached before the ListView loads its ScrollViewer
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void AssociatedObject_Loaded( object sender, RoutedEventArgs e )
    {
      this.scroll = GetScrollViewer( this.AssociatedObject );
      if( this.scroll != null )
      {
        this.scroll.ViewChanged += this.scrollViewChanged;
      }
    }

    protected override void OnDetaching( )
    {
      this.scroll.ViewChanged -= this.scrollViewChanged;
      this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
      this.scroll = null;
      base.OnDetaching( );
    }
    
    private void scrollViewChanged( object sender, ScrollViewerViewChangedEventArgs e )
    {
      double progress = this.scroll.ScrollableHeight - this.scroll.VerticalOffset;
      if( this.atEnd && progress > Threshold )
      {
        //progress > Threshold means that user scrolled back up a little
        this.atEnd = false;
      }
      else if(!this.atEnd && progress <= Threshold )
      {
        //we were not at end, but now we are
        this.atEnd = true;
        this.LoadMoreObjectsCommand?.Execute(null);
      }
    }

    public static ScrollViewer GetScrollViewer( DependencyObject depObj )
    {
      if( depObj is ScrollViewer ) return depObj as ScrollViewer;

      for( int i = 0; i < VisualTreeHelper.GetChildrenCount( depObj ); i++ )
      {
        var child = VisualTreeHelper.GetChild( depObj, i );

        var result = GetScrollViewer( child );
        if( result != null ) return result;
      }
      return null;
    }
  }
}
