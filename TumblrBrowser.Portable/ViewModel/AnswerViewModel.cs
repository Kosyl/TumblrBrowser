using TumblrBrowser.Portable.Model;
using TumblrBrowser.Portable.Services;

namespace TumblrBrowser.Portable.ViewModel
{
  public class AnswerViewModel : PostViewModel<AnswerPost>
  {
    public AnswerViewModel( IUriLauncher launcher ) : base( launcher )
    {
    }
  }
}