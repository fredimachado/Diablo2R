using System.IO;
using Xunit;

namespace Diablo2R.Core.Tests
{
    public class AttributesTests
    {
        [Fact]
        public void GivenAttributeBytes_ShouldReturnCorrectValues()
        {
            // Arrange
            var buffer = new byte[]
            {
                0x67, 0x66, 0x00, 0x48, 0x08, 0x40, 0x81, 0x80,
                0x0F, 0x06, 0x84, 0x60, 0x00, 0xE0, 0x0B, 0x1C,
                0x00, 0xE8, 0x02, 0x08, 0x00, 0x45, 0x40, 0x02,
                0x80, 0x10, 0xA0, 0x00, 0x00, 0x0E, 0x2C, 0x00,
                0x40, 0x03, 0x0C, 0x10, 0x0D, 0xB6, 0x4B, 0x01,
                0x00, 0x1C, 0x48, 0x59, 0x00, 0x78, 0xF0, 0x05,
                0x01, 0xE0, 0x3F
            };
            var stream = new MemoryStream(buffer);
            using var reader = new BinaryReader(stream);

            // Act
            var sut = new Attributes(reader);

            // Assert
            Assert.Equal<uint>(36, sut.Strength);
            Assert.Equal<uint>(20, sut.Energy);
            Assert.Equal<uint>(31, sut.Dexterity);
            Assert.Equal<uint>(33, sut.Vitality);
            Assert.Equal<uint>(0, sut.UnusedStats);
            Assert.Equal<uint>(0, sut.UnusedSkills);
            Assert.Equal<uint>(95, sut.CurrentHP);
            Assert.Equal<uint>(93, sut.MaxHP);
            Assert.Equal<uint>(34, sut.CurrentMana);
            Assert.Equal<uint>(33, sut.MaxMana);
            Assert.Equal<uint>(112, sut.CurrentStamina);
            Assert.Equal<uint>(104, sut.MaxStamina);
            Assert.Equal<uint>(8, sut.Level);
            Assert.Equal<uint>(42459, sut.Experience);
            Assert.Equal<uint>(5714, sut.Gold);
            Assert.Equal<uint>(4191, sut.StashedGold);
        }
    }
}
