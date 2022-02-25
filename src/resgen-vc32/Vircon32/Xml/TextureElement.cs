using System.Xml.Serialization;

namespace resgen_vc32.Vircon32.Xml
{
    [XmlRoot("texture")]
    public class TextureElement
    {
        [XmlAttribute("path")]
        public string? Path { get; set; }
    }
}
