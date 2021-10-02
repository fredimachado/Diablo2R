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

        public Attributes(BinaryReader reader)
        {
            reader.ReadInt16(); // Header

            var bitReader = new BitReader(reader);

            int id;
            while ((id = bitReader.ReadBits(9)) != EndOfAttributes)
            {
                var attribute = (Attribute)id;
                var bitCount = attribute.BitCount();
                var attributeValue = (uint)bitReader.ReadBits(bitCount);

                switch (attribute)
                {
                    case Attribute.Strength:
                        Strength = attributeValue;
                        break;
                    case Attribute.Energy:
                        Energy = attributeValue;
                        break;
                    case Attribute.Dexterity:
                        Dexterity = attributeValue;
                        break;
                    case Attribute.Vitality:
                        Vitality = attributeValue;
                        break;
                    case Attribute.UnusedStats:
                        UnusedStats = attributeValue;
                        break;
                    case Attribute.UnusedSkills:
                        UnusedSkills = attributeValue;
                        break;
                    case Attribute.CurrentHP:
                        CurrentHP = attributeValue / 256;
                        break;
                    case Attribute.MaxHP:
                        MaxHP = attributeValue / 256;
                        break;
                    case Attribute.CurrentMana:
                        CurrentMana = attributeValue / 256;
                        break;
                    case Attribute.MaxMana:
                        MaxMana = attributeValue / 256;
                        break;
                    case Attribute.CurrentStamina:
                        CurrentStamina = attributeValue / 256;
                        break;
                    case Attribute.MaxStamina:
                        MaxStamina = attributeValue / 256;
                        break;
                    case Attribute.Level:
                        Level = attributeValue;
                        break;
                    case Attribute.Experience:
                        Experience = attributeValue;
                        break;
                    case Attribute.Gold:
                        Gold = attributeValue;
                        break;
                    case Attribute.StashedGold:
                        StashedGold = attributeValue;
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public enum Attribute
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

    public static class AttributeExtensions
    {
        public static byte BitCount(this Attribute attribute)
        {
            return attribute switch
            {
                Attribute.Strength => 10,
                Attribute.Energy => 10,
                Attribute.Dexterity => 10,
                Attribute.Vitality => 10,
                Attribute.UnusedStats => 10,
                Attribute.UnusedSkills => 8,
                Attribute.CurrentHP => 21,
                Attribute.MaxHP => 21,
                Attribute.CurrentMana => 21,
                Attribute.MaxMana => 21,
                Attribute.CurrentStamina => 21,
                Attribute.MaxStamina => 21,
                Attribute.Level => 7,
                Attribute.Experience => 32,
                Attribute.Gold => 25,
                Attribute.StashedGold => 25,
                _ => throw new InvalidOperationException()
            };
        }
    }
}