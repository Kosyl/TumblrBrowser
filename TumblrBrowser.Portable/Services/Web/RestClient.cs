using System.Net.Http;
using System.Threading.Tasks;

namespace TumblrBrowser.Portable.Services
{
  /// <summary>
  /// A simple web request wrapper for HTTP GET
  /// </summary>
  public class RestClient
  {
    public static async Task<string> GetAsync( string url )
    {
      HttpClient client = new HttpClient( );
      
      Task<string> getStringTask = client.GetStringAsync( url );
      
      return await getStringTask;
    }
  }
}
