using System.Xml.Serialization;

namespace TumblrBrowser.Portable.Model
{
  [XmlRoot( "post", Namespace = "" )]
  public class RegularPost : PostBase
  {
    [XmlElement( "regular-title" )]
    public string Title { get; set; }
    
    [XmlElement( "regular-body" )]
    public string Body { get; set; }
  }
}
