using System.Xml.Serialization;

namespace TumblrBrowser.Portable.Model
{
  public class PostBase
  {
    [XmlAttribute( "date-gmt" )]
    public string Date { get; set; }

    [XmlAttribute("type")]
    public string PostType { get; set; }

    [XmlAttribute( "id" )]
    public string PostId { get; set; }

    [XmlAttribute( "slug" )]
    public string Slug { get; set; }

    [XmlAttribute( "url" )]
    public string Url { get; set; }

    public string PostDescription => this.Slug.Replace( '-', ' ' );

    public virtual string PhotoUrl => null;
  }
}
