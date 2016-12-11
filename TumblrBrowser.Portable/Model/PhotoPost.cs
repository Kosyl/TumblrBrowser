using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace TumblrBrowser.Portable.Model
{
  [XmlRoot( "photo", Namespace = "" )]
  public class PhotoSetPhoto
  {
    [XmlElement( "photo-caption" )]
    public string Caption { get; set; }

    [XmlElement( "photo-url" )]
    public List<ScaledPhoto> Photos { get; set; }

    public ScaledPhoto SmallestPhoto => this.Photos?.OrderBy( o => o.MaxWidth ).FirstOrDefault( );
    public ScaledPhoto LargestPhoto => this.Photos?.OrderBy( o => o.MaxWidth ).LastOrDefault( );
  }

  [XmlRoot( "photoset", Namespace = "" )]
  public class PhotoSet
  {
    [XmlElement( "photo" )]
    public List<PhotoSetPhoto> Photos { get; set; }
  }

  [XmlRoot( "photo-url", Namespace = "" )]
  public class ScaledPhoto
  {
    [XmlAttribute( "max-width" )]
    public int MaxWidth { get; set; }

    [XmlText]
    public string Url { get; set; }
  }

  [XmlRoot("post", Namespace = "")]
  public class PhotoPost : PostBase
  {
    [XmlElement("photo-caption")]
    public string Caption { get; set; }
    
    public override string PhotoUrl => this.SmallestPhoto?.Url;

    [XmlElement( "photo-url" )]
    public List<ScaledPhoto> Photos { get; set; }

    [XmlElement( "photoset" )]
    public PhotoSet PhotoSet { get; set; }

    public bool HasPhotoSet => this.PhotoSet?.Photos?.Any( ) ?? false;

    public ScaledPhoto SmallestPhoto => this.Photos?.OrderBy( o => o.MaxWidth ).FirstOrDefault( );
    public ScaledPhoto LargestPhoto => this.Photos?.OrderBy( o => o.MaxWidth ).LastOrDefault();
  }
}
