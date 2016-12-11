using System.Collections.Generic;
using TumblrBrowser.Portable.Model;

namespace TumblrBrowser.Portable.Services.PostParser
{
  /// <summary>
  /// Interface for transforming content returned from Tumblr API into C# classes
  /// </summary>
  public interface IPostParser
  {
    /// <summary>
    /// Parse Tumblr GET response into classes deriving from PostBase
    /// </summary>
    /// <param name="content">String containing the entire Tumblr response, as returned from the API</param>
    /// <returns></returns>
    List<PostBase> Parse( string content );
  }
}
