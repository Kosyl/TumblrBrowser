using System.Xml.Serialization;

namespace TumblrBrowser.Portable.Model
{
  [XmlRoot( "post", Namespace = "" )]
  public class LinkPost: PostBase
  {
    [XmlElement( "link-text" )]
    public string Text { get; set; }
    
    [XmlElement( "link-url" )]
    public string LinkUrl { get; set; }

    [XmlElement( "link-description" )]
    public string Description { get; set; }
  }
}
