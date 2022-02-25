using System.Xml.Serialization;

namespace resgen_vc32.Vircon32.Xml
{
    [XmlRoot("rom")]
    public class RomElement
    {
        [XmlAttribute("type")]
        public string? Type { get; set; }

        [XmlAttribute("title")]
        public string? Title { get; set; }

        [XmlAttribute("version")]
        public string? Version { get; set; }
    }
}
