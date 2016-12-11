using TumblrBrowser.Portable.Model;
using TumblrBrowser.Portable.Services;

namespace TumblrBrowser.Portable.ViewModel
{
  public class RegularPostViewModel : PostViewModel<RegularPost>
  {
    public RegularPostViewModel( IUriLauncher launcher ): base( launcher )
    {
    }
  }
}