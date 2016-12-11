using System.Xml.Serialization;

namespace TumblrBrowser.Portable.Model
{
  [XmlRoot( "post", Namespace = "" )]
  public class QuotePost : PostBase
  {
    [XmlElement( "quote-text" )]
    public string Text { get; set; }

    [XmlElement( "quote-source" )]
    public string Source { get; set; }
  }
}
