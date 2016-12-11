using TumblrBrowser.Portable.Model;
using TumblrBrowser.Portable.Services;

namespace TumblrBrowser.Portable.ViewModel
{
  public class QuoteViewModel : PostViewModel<QuotePost>
  {
    public QuoteViewModel( IUriLauncher launcher ): base( launcher )
    {
    }
  }
}