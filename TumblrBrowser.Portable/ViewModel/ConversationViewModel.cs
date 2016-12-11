using TumblrBrowser.Portable.Model;
using TumblrBrowser.Portable.Services;

namespace TumblrBrowser.Portable.ViewModel
{
  public class ConversationViewModel: PostViewModel<ConversationPost>
  {
    public ConversationViewModel( IUriLauncher launcher ): base( launcher )
    {
    }
  }
}