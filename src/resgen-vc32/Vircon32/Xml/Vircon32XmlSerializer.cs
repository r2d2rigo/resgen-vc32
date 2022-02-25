using System.Xml.Serialization;

namespace resgen_vc32.Vircon32.Xml
{
    public class Vircon32XmlSerializer
    {
        public RomDefinition? Deserialize(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                var serializer = new XmlSerializer(typeof(RomDefinition));

                return (RomDefinition?)serializer.Deserialize(reader);
            }
        }
    }
}
