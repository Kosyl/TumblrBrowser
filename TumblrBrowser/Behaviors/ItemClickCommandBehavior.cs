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
  /// Simple behavior binding the ListView's ItemClick event to a command in a ViewModel
  /// </summary>
  public class ItemClickCommandBehavior: Behavior<ListView>
  {
    public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
      "Command", typeof( ICommand ), typeof( ItemClickCommandBehavior ), new PropertyMetadata( default(ICommand) ) );

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

      this.AssociatedObject.ItemClick += AssociatedObject_ItemClick;
    }

    private void AssociatedObject_ItemClick( object sender, ItemClickEventArgs e )
    {
      this.Command?.Execute(e.ClickedItem);
    }
    
    protected override void OnDetaching( )
    {
      this.AssociatedObject.ItemClick -= AssociatedObject_ItemClick;
      base.OnDetaching( );
    }
  }
}
