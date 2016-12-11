using System.Collections.Generic;
using System.Threading.Tasks;
using TumblrBrowser.Portable.Model;

namespace TumblrBrowser.Portable.Services
{
  /// <summary>
  /// Interface to reflect the Tumblr API, works as a repository of posts
  /// </summary>
  public interface ITumblrApiService
  {
    Task<IEnumerable<PostBase>> FetchPosts(string username, int offset, int count);
  }
}
