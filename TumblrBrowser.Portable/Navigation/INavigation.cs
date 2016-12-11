using TumblrBrowser.Portable.Model;

namespace TumblrBrowser.Portable.Navigation
{
  public interface INavigation
  {
    /// <summary>
    /// Navigate to the page showing selected post. Target page type is chosen depending on the post type.
    /// </summary>
    /// <param name="post">Post to show</param>
    void ShowPost( PostBase post );
  }
}
