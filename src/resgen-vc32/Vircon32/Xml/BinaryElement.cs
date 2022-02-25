using System.Xml.Serialization;

namespace resgen_vc32.Vircon32.Xml
{
    [XmlRoot("binary")]
    public class BinaryElement
    {
        [XmlAttribute("path")]
        public string? Path { get; set; }
    }
}
