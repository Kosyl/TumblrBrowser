using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;
using TumblrBrowser.Portable.Model;

namespace TumblrBrowser.Portable.Services.PostParser
{
  public class PostParser: IPostParser
  {
    public PostParser( )
    {
    }

    public List<PostBase> Parse( string content )
    {
      var xml = XElement.Parse( content );

      var result = new List<PostBase>( );

      var postsNode = xml.Element( XName.Get( "posts" ) );

      foreach( var postNode in postsNode.Elements( ) )
      {
        var post = this.ParsePost( postNode );
        if( post != null )
          result.Add( post );
      }

      return result;
    }

    private PostBase ParsePost( XElement postNode )
    {
      string type = postNode.Attribute( XName.Get( "type" ) ).Value;
      
      //we have to manually derive the class of target post object
      switch( type )
      {
        case PostType.Regular:
          var regular = (RegularPost)Deserialize( postNode, typeof( RegularPost ) );

          //blockquotes are so small its unreadable, we remove them for clarity
          regular.Body = regular.Body?.Replace( "<blockquote>", "" ).Replace( "</blockquote>", "" );
          return regular;
        case PostType.Link:
          return Deserialize( postNode, typeof( LinkPost ) );
        case PostType.Answer:
          return Deserialize( postNode, typeof( AnswerPost ) );
        case PostType.Quote:
          var quote = (QuotePost) Deserialize( postNode, typeof( QuotePost ) );

          //blockquotes are so small its unreadable, we remove them for clarity
          quote.Text = quote.Text.Replace( "<blockquote>", "" ).Replace( "</blockquote>", "" );
          return quote;
        case PostType.Photo:
          return Deserialize( postNode, typeof( PhotoPost ) );
        case PostType.Video:
          return Deserialize( postNode, typeof( VideoPost ) );
        case PostType.Audio:
          return Deserialize( postNode, typeof( AudioPost ) );
        case PostType.Conversation:
          return Deserialize( postNode, typeof( ConversationPost ) );
        default:
          throw new ArgumentOutOfRangeException( );
      }
    }

    private static PostBase Deserialize( XElement element, Type postType )
    {
      var serializer = new XmlSerializer( postType );
      return (PostBase) serializer.Deserialize( element.CreateReader( ) );
    }
  }
}