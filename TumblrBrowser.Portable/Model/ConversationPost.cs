using System.Collections.Generic;
using System.Xml.Serialization;

namespace TumblrBrowser.Portable.Model
{
  [XmlRoot( "photo", Namespace = "" )]
  public class ConversationLine
  {
    [XmlAttribute( "label" )]
    public string Label { get; set; }

    [XmlText]
    public string Text { get; set; }
  }

  [XmlRoot( "conversation", Namespace = "" )]
  public class ConversationData
  {
    [XmlElement( "line" )]
    public List<ConversationLine> Lines { get; set; }
  }


  [XmlRoot( "post", Namespace = "" )]
  public class ConversationPost : PostBase
  {
    [XmlElement( "conversation-title" )]
    public string Title { get; set; }
    
    [XmlElement( "conversation" )]
    public ConversationData Conversation { get; set; }
  }
}
