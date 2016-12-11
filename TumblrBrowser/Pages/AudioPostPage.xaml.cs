using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using TumblrBrowser.Portable.Model;
using TumblrBrowser.Portable.ViewModel;

namespace TumblrBrowser.Pages
{
  public sealed partial class AudioPostPage: Page
  {
    public AudioPostPage( )
    {
      this.InitializeComponent( );

      this.DataContext = ViewModelLocator.Audio;
    }

    public AudioViewModel ViewModel => this.DataContext as AudioViewModel;

    protected override void OnNavigatedTo( NavigationEventArgs e )
    {
      this.ViewModel.Activate( e.Parameter as AudioPost );
    }
  }
}