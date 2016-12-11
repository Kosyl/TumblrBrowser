using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using TumblrBrowser.Portable.Model;
using TumblrBrowser.Portable.ViewModel;

namespace TumblrBrowser.Pages
{
  /// <summary>
  ///   An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class ConversationPostPage: Page
  {
    public ConversationPostPage( )
    {
      this.InitializeComponent( );

      this.DataContext = ViewModelLocator.Conversation;
    }

    public ConversationViewModel ViewModel => this.DataContext as ConversationViewModel;

    protected override void OnNavigatedTo( NavigationEventArgs e )
    {
      this.ViewModel.Activate( e.Parameter as ConversationPost );
    }
  }
}