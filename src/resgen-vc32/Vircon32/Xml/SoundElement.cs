using System.Xml.Serialization;

namespace resgen_vc32.Vircon32.Xml
{
    [XmlRoot("sound")]
    public class SoundElement
    {
        [XmlAttribute("path")]
        public string? Path { get; set; }
    }
}
