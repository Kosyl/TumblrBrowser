using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using TumblrBrowser.Portable.ViewModel;

namespace TumblrBrowser.Pages
{
  public sealed partial class PostsListPage: Page
  {
    public PostsListPage( )
    {
      this.InitializeComponent( );

      this.NavigationCacheMode = NavigationCacheMode.Required;

      this.DataContext = ViewModelLocator.PostsList;
    }

    public PostsListViewModel ViewModel => this.DataContext as PostsListViewModel;
    
    protected override void OnNavigatedTo( NavigationEventArgs e )
    {
      bool cameBack = e.NavigationMode == NavigationMode.Back;
      this.ViewModel.Activate( cameBack );
    }
  }
}