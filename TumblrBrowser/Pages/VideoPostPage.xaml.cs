using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using TumblrBrowser.Portable.Model;
using TumblrBrowser.Portable.ViewModel;

namespace TumblrBrowser.Pages
{
  public sealed partial class VideoPostPage : Page
  {
    public VideoPostPage( )
    {
      this.InitializeComponent( );

      this.DataContext = ViewModelLocator.Video;
    }

    public VideoViewModel ViewModel => this.DataContext as VideoViewModel;

    protected override void OnNavigatedTo( NavigationEventArgs e )
    {
      this.ViewModel.Activate( e.Parameter as VideoPost );
    }
  }
}
