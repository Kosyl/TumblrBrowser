using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumblrBrowser.Portable.Model;
using TumblrBrowser.Portable.Services.PostParser;

namespace TumblrBrowser.Portable.Services
{
  public class TumblrApiService: ITumblrApiService
  {
    private IPostParser postParser;

    public TumblrApiService( IPostParser postParser )
    {
      this.postParser = postParser;
    }

    private const string FetchRequestUriFormat = "http://{0}.tumblr.com/api/read";

    private string CreateRequestUri( string username, int offset, int count )
    {
      var uri = String.Format( FetchRequestUriFormat, username );
      
      Dictionary<string,string> parameters = new Dictionary<string, string>();

      if( offset > 0 )
        parameters[ "start" ] = offset.ToString();

      if( count > 0 )
        parameters[ "num" ] = count.ToString( );
      
      if( parameters.Any( ) )
        uri += "?" + String.Join( "&", parameters.Select( o => $"{o.Key}={o.Value}" ) );

      return uri;
    }

    public async Task<IEnumerable<PostBase>> FetchPosts( string username, int offset, int count )
    {
      var requestUri = this.CreateRequestUri( username, offset, count );

      try
      {
        var response = await RestClient.GetAsync( requestUri );
        return this.postParser.Parse( response );
      }
      catch
      {
        return Enumerable.Empty<PostBase>( );
      }
    }
  }
}
