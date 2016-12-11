using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using TumblrBrowser.Portable.Model;
using TumblrBrowser.Portable.ViewModel;

namespace TumblrBrowser.Pages
{
  public sealed partial class PhotoPage: Page
  {
    public PhotoPage( )
    {
      this.InitializeComponent( );

      this.DataContext = ViewModelLocator.Photo;
    }

    public PhotoViewModel ViewModel => this.DataContext as PhotoViewModel;

    protected override void OnNavigatedTo( NavigationEventArgs e )
    {
      this.ViewModel.Activate( e.Parameter as PhotoPost );
    }
  }
}