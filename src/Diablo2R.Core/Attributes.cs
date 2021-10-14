using System;
using System.IO;

namespace Diablo2R.Core
{
    public sealed class Attributes
    {
        private const int EndOfAttributes = 0x1ff;

        public uint Strength { get; }
        public uint Energy { get; }
        public uint Dexterity { get; }
        public uint Vitality { get; }
        public uint UnusedStats { get; }
        public uint UnusedSkills { get; }
        public uint CurrentHP { get; }
        public uint MaxHP { get; }
        public uint CurrentMana { get; }
        public uint MaxMana { get; }
        public uint CurrentStamina { get; }
        public uint MaxStamina { get; }
        public uint Level { get; }
        public uint Experience { get; }
        public uint Gold { get; }
        public uint StashedGold { get; }

        internal Attributes(BinaryReader reader)
        {
            reader.ReadInt16(); // Header

            var bitReader = new BitReader(reader);

            int id;
            while ((id = bitReader.ReadBits(9)) != EndOfAttributes)
            {
                var attribute = (D2sAttribute)id;
                var bitCount = attribute.BitCount();
                var attributeValue = (uint)bitReader.ReadBits(bitCount);

                switch (attribute)
                {
                    case D2sAttribute.Strength:
                        Strength = attributeValue;
                        break;
                    case D2sAttribute.Energy:
                        Energy = attributeValue;
                        break;
                    case D2sAttribute.Dexterity:
                        Dexterity = attributeValue;
                        break;
                    case D2sAttribute.Vitality:
                        Vitality = attributeValue;
                        break;
                    case D2sAttribute.UnusedStats:
                        UnusedStats = attributeValue;
                        break;
                    case D2sAttribute.UnusedSkills:
                        UnusedSkills = attributeValue;
                        break;
                    case D2sAttribute.CurrentHP:
                        CurrentHP = attributeValue / 256;
                        break;
                    case D2sAttribute.MaxHP:
                        MaxHP = attributeValue / 256;
                        break;
                    case D2sAttribute.CurrentMana:
                        CurrentMana = attributeValue / 256;
                        break;
                    case D2sAttribute.MaxMana:
                        MaxMana = attributeValue / 256;
                        break;
                    case D2sAttribute.CurrentStamina:
                        CurrentStamina = attributeValue / 256;
                        break;
                    case D2sAttribute.MaxStamina:
                        MaxStamina = attributeValue / 256;
                        break;
                    case D2sAttribute.Level:
                        Level = attributeValue;
                        break;
                    case D2sAttribute.Experience:
                        Experience = attributeValue;
                        break;
                    case D2sAttribute.Gold:
                        Gold = attributeValue;
                        break;
                    case D2sAttribute.StashedGold:
                        StashedGold = attributeValue;
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public enum D2sAttribute
    {
        Strength,
        Energy,
        Dexterity,
        Vitality,
        UnusedStats,
        UnusedSkills,
        CurrentHP,
        MaxHP,
        CurrentMana,
        MaxMana,
        CurrentStamina,
        MaxStamina,
        Level,
        Experience,
        Gold,
        StashedGold
    }

    internal static class AttributeExtensions
    {
        public static byte BitCount(this D2sAttribute attribute)
        {
            return attribute switch
            {
                D2sAttribute.Strength => 10,
                D2sAttribute.Energy => 10,
                D2sAttribute.Dexterity => 10,
                D2sAttribute.Vitality => 10,
                D2sAttribute.UnusedStats => 10,
                D2sAttribute.UnusedSkills => 8,
                D2sAttribute.CurrentHP => 21,
                D2sAttribute.MaxHP => 21,
                D2sAttribute.CurrentMana => 21,
                D2sAttribute.MaxMana => 21,
                D2sAttribute.CurrentStamina => 21,
                D2sAttribute.MaxStamina => 21,
                D2sAttribute.Level => 7,
                D2sAttribute.Experience => 32,
                D2sAttribute.Gold => 25,
                D2sAttribute.StashedGold => 25,
                _ => throw new InvalidOperationException()
            };
        }
    }
}