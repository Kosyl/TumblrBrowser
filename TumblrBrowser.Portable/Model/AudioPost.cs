using System.Xml.Serialization;

namespace TumblrBrowser.Portable.Model
{
  [XmlRoot( "post", Namespace = "" )]
  public class AudioPost : PostBase
  {
    [XmlElement( "audio-caption" )]
    public string Caption { get; set; }
    
    [XmlElement( "audio-player" )]
    public string AudioUrl { get; set; }

    [XmlElement( "id3-artist" )]
    public string Artist { get; set; }

    [XmlElement( "id3-album" )]
    public string Album { get; set; }

    [XmlElement( "id3-title" )]
    public string Title { get; set; }
  }
}
