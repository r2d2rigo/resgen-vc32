using resgen_vc32.Vircon32.Xml;
using System.IO;
using Xunit;

namespace resgen_vc32.Test
{
    public class Vircon32XmlSerializerUnitTest
    {
        [Fact]
        public void Serializer_ShouldRead()
        {
            var inputFile = File.OpenRead("2048.xml");
            var serializer = new Vircon32XmlSerializer();
            var romDefinition = serializer.Deserialize(inputFile);

            Assert.NotNull(romDefinition);
            
            Assert.NotNull(romDefinition.Rom);
            Assert.Equal("1.0", romDefinition.Version);

            Assert.Equal("cartridge", romDefinition.Rom.Type);
            Assert.Equal("2048", romDefinition.Rom.Title);
            Assert.Equal("1.0", romDefinition.Rom.Version);

            Assert.NotNull(romDefinition.Binary);
            Assert.Equal("obj/Main.vbin", romDefinition.Binary.Path);

            Assert.NotEmpty(romDefinition.Textures);
            Assert.Equal(1, romDefinition.Textures.Length);
            Assert.Equal("obj/Texture2048.vtex", romDefinition.Textures[0].Path);

            Assert.NotEmpty(romDefinition.Sounds);
            Assert.Equal(15, romDefinition.Sounds.Length);
            Assert.Equal("obj/MusicTitle.vsnd", romDefinition.Sounds[0].Path);
        }
    }
}