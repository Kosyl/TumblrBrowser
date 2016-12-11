using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using TumblrBrowser.Portable.Model;
using TumblrBrowser.Portable.ViewModel;

namespace TumblrBrowser.Pages
{
  public sealed partial class QuotePage: Page
  {
    public QuotePage( )
    {
      this.InitializeComponent( );

      this.DataContext = ViewModelLocator.Quote;
    }

    public QuoteViewModel ViewModel => this.DataContext as QuoteViewModel;

    protected override void OnNavigatedTo( NavigationEventArgs e )
    {
      this.ViewModel.Activate( e.Parameter as QuotePost );
    }
  }
}