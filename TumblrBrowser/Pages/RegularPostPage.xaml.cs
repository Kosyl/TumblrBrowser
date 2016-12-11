using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using TumblrBrowser.Portable.Model;
using TumblrBrowser.Portable.ViewModel;

namespace TumblrBrowser.Pages
{
  public sealed partial class RegularPostPage: Page
  {
    public RegularPostPage( )
    {
      this.InitializeComponent( );

      this.DataContext = ViewModelLocator.RegularPost;
    }

    public RegularPostViewModel ViewModel => this.DataContext as RegularPostViewModel;

    protected override void OnNavigatedTo( NavigationEventArgs e )
    {
      this.ViewModel.Activate( e.Parameter as RegularPost );
    }
  }
}