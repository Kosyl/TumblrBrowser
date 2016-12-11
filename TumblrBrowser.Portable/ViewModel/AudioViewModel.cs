using TumblrBrowser.Portable.Model;
using TumblrBrowser.Portable.Services;

namespace TumblrBrowser.Portable.ViewModel
{
  public class AudioViewModel : PostViewModel<AudioPost>
  {
    public AudioViewModel( IUriLauncher launcher ) : base( launcher )
    {
    }
  }
}