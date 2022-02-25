using resgen_vc32.Vircon32.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace resgen_vc32
{
    public class ResourcesHeaderWriter :
        IDisposable
    {
        private bool _disposedValue;
        private StreamWriter _streamWriter;

        public ResourcesHeaderWriter(Stream stream)
        {
            _streamWriter = new StreamWriter(stream);
        }

        public void Write(RomDefinition romDefinition)
        {
            _streamWriter.WriteLine("#ifndef __RESOURCES_H__");
            _streamWriter.WriteLine("#define __RESOURCES_H__");
            _streamWriter.WriteLine();
            _streamWriter.WriteLine();

            if (romDefinition.Textures != null &&
                romDefinition.Textures.Length > 0)
            {
                var textureIndex = 0;

                _streamWriter.WriteLine("// TEXTURES");
                _streamWriter.WriteLine();

                foreach (var texture in romDefinition.Textures)
                {
                    var textureName = Path.GetFileNameWithoutExtension(texture.Path);
                    _streamWriter.WriteLine($"#define {textureName.PadRight(40)} {textureIndex}");

                    textureIndex++;
                }

                _streamWriter.WriteLine();
            }

            if (romDefinition.Sounds != null &&
                romDefinition.Sounds.Length > 0)
            {
                var soundIndex = 0;

                _streamWriter.WriteLine("// SOUNDS");
                _streamWriter.WriteLine();

                foreach (var sound in romDefinition.Sounds)
                {
                    var soundName = Path.GetFileNameWithoutExtension(sound.Path);
                    _streamWriter.WriteLine($"#define {soundName.PadRight(40)} {soundIndex}");

                    soundIndex++;
                }

                _streamWriter.WriteLine();
            }

            _streamWriter.WriteLine();
            _streamWriter.WriteLine("#endif");

            _streamWriter.Flush();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _streamWriter?.Flush();
                    _streamWriter?.Close();
                    _streamWriter?.Dispose();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
