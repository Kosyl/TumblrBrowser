using TumblrBrowser.Portable.Model;
using TumblrBrowser.Portable.Services;

namespace TumblrBrowser.Portable.ViewModel
{
  public class LinkViewModel : PostViewModel<LinkPost>
  {
    public LinkViewModel( IUriLauncher launcher ): base( launcher )
    {
    }
  }
}