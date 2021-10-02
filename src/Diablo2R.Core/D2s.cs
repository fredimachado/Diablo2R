using System.IO;

namespace Diablo2R.Core
{
    public sealed class D2s
    {
        public Header Header { get; }
        public Attributes Attributes { get; }

        public D2s(string filePath) : this(File.OpenRead(filePath))
        {
        }

        public D2s(Stream stream)
        {
            using var reader = new BinaryReader(stream);

            Header = new Header(reader);
            Attributes = new Attributes(reader);
        }
    }
}
