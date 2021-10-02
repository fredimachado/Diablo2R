using System.IO;

namespace Diablo2R.Core
{
    internal class BitReader
    {
        private readonly BinaryReader reader;
        private byte currentByte;
        private byte position;

        public BitReader(BinaryReader reader)
        {
            this.reader = reader;
            currentByte = reader.ReadByte();
        }

        public int ReadBits(int count)
        {
            int value = 0;
            for (int i = 0; i < count; i++)
            {
                if (position == 8)
                {
                    position = 0;
                    currentByte = reader.ReadByte();
                }

                var isBitOn = (currentByte >> position & 1) == 1;

                if (isBitOn)
                {
                    value |= 1 << i;
                }

                position++;
            }
            return value;
        }
    }
}
