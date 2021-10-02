using System;
using Xunit;
using Diablo2R.Core;
using System.IO;

namespace Diablo2R.Core.Tests
{
    public class BitReaderTests
    {
        [Fact]
        public void GivenTwoBytes_WhenReading10Bits_ShouldReturnCorrectValue()
        {
            // Arrange
            // 0x00     0x01
            // 00000000 00000001
            var buffer = new byte[] { 0x00, 0x01 };
            var stream = new MemoryStream(buffer);
            using var reader = new BinaryReader(stream);
            var sut = new BitReader(reader);

            // Act
            var value = sut.ReadBits(10); // ... 0100000000 (256)

            // Assert
            Assert.Equal(256, value);
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void GivenBytes_WhenReadingXBits_ShouldReturnCorrectValue(byte[] buffer, int bits, int expected)
        {
            var stream = new MemoryStream(buffer);
            using var reader = new BinaryReader(stream);
            var sut = new BitReader(reader);

            // Act
            var value = sut.ReadBits(bits);

            // Assert
            Assert.Equal(expected, value);
        }

        public static object[][] GetTestData()
        {
            return new object[][]
            {
                // ... represents the rest of the most significant bits (integers have 32 bits)
                // They will all be 0's

                // 00000000 00000001 = ...0100000000
                new object[] { new byte[] { 0x00, 0x01 }, 10, 256 },
                // 00000001 00000001 = ...0100000001
                new object[] { new byte[] { 0x01, 0x01 }, 10, 257 },
                // 00000001 00000000 = ...0000000001
                new object[] { new byte[] { 0x01, 0x00 }, 10, 1 },
                // 00000000 00000010 = ...1000000000
                new object[] { new byte[] { 0x00, 0x02 }, 10, 512 },
                // 00000000 00001010 = ...101000000000
                new object[] { new byte[] { 0x00, 0x0A }, 12, 2560 },
            };
        }
    }
}
