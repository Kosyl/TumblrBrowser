using TumblrBrowser.Portable.Model;
using TumblrBrowser.Portable.Services;

namespace TumblrBrowser.Portable.ViewModel
{
  public class VideoViewModel : PostViewModel<VideoPost>
  {
    public VideoViewModel( IUriLauncher launcher ): base( launcher )
    {
    }
  }
  
}