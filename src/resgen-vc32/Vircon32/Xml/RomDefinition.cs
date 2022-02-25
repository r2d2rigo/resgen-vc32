using System.Xml.Serialization;

namespace resgen_vc32.Vircon32.Xml
{
    [XmlRoot("rom-definition")]
    public class RomDefinition
    {
        [XmlAttribute("version")]
        public string? Version { get; set; }

        [XmlElement("rom")]
        public RomElement? Rom { get; set; }

        [XmlElement("binary")]
        public BinaryElement? Binary { get; set; }

        [XmlArray("textures")]
        [XmlArrayItem("texture")]
        public TextureElement[]? Textures { get; set; }

        [XmlArray("sounds")]
        [XmlArrayItem("sound")]
        public SoundElement[]? Sounds { get; set; }
    }
}
