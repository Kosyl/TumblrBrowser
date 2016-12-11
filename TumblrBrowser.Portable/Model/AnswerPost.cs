using System.Xml.Serialization;

namespace TumblrBrowser.Portable.Model
{
  [XmlRoot( "post", Namespace = "" )]
  public class AnswerPost : PostBase
  {
    [XmlElement( "question" )]
    public string Question { get; set; }
    
    [XmlElement( "answer" )]
    public string Answer { get; set; }
  }
}
