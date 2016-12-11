using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using TumblrBrowser.Portable.Model;
using TumblrBrowser.Portable.ViewModel;

namespace TumblrBrowser.Pages
{
  public sealed partial class AnswerPostPage: Page
  {
    public AnswerPostPage( )
    {
      this.InitializeComponent( );

      this.DataContext = ViewModelLocator.Answer;
    }

    public AnswerViewModel ViewModel => this.DataContext as AnswerViewModel;

    protected override void OnNavigatedTo( NavigationEventArgs e )
    {
      this.ViewModel.Activate( e.Parameter as AnswerPost );
    }
  }
}