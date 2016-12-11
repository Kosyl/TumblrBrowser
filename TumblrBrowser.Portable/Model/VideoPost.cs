using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace TumblrBrowser.Portable.Model
{
  [XmlRoot( "video-player", Namespace = "" )]
  public class ScaledVideo
  {
    [XmlAttribute( "max-width" )]
    public int MaxWidth { get; set; }

    [XmlText]
    public string PlayerInfo { get; set; }
  }

  [XmlRoot( "post", Namespace = "" )]
  public class VideoPost : PostBase
  {
    [XmlElement( "video-caption" )]
    public string Caption { get; set; }

    [XmlElement( "video-player" )]
    public List<ScaledVideo> Videos { get; set; }
    
    public bool HasVideos => this.Videos?.Any( ) ?? false;
    
    public ScaledVideo LargestVideo => this.Videos?.OrderBy( o => o.MaxWidth ).LastOrDefault( );
  }
}
