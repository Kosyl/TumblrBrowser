using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using TumblrBrowser.Portable.Model;
using TumblrBrowser.Portable.ViewModel;

namespace TumblrBrowser.Pages
{
  public sealed partial class LinkPostPage: Page
  {
    public LinkPostPage( )
    {
      this.InitializeComponent( );

      this.DataContext = ViewModelLocator.Link;
    }

    public LinkViewModel ViewModel => this.DataContext as LinkViewModel;

    protected override void OnNavigatedTo( NavigationEventArgs e )
    {
      this.ViewModel.Activate( e.Parameter as LinkPost );
    }
  }
}