using System;
using System.IO;
using System.Text;

namespace Diablo2R.Core
{
    public sealed class Header
    {
        public string CharacterName { get; }
        public CharacterClass CharacterClass { get; }
        public int CharacterLevel { get; }
        public DateTime LastPlayed { get; }

        public Header(BinaryReader reader)
        {
            var headerBytes = reader.ReadBytes(765);

            CharacterName = Encoding.ASCII.GetString(headerBytes[20..36])
                .Trim('\0');
            CharacterClass = (CharacterClass)headerBytes[40..41][0];
            CharacterLevel = headerBytes[43..44][0];

            var lastPlayedTimestamp = BitConverter.ToUInt32(headerBytes[48..52]);
            LastPlayed = new DateTime(1970, 1, 1)
                .AddSeconds(lastPlayedTimestamp)
                .ToLocalTime();
        }
    }

    public enum CharacterClass
    {
        Amazon,
        Sorceress,
        Necromancer,
        Paladin,
        Barbarian,
        Druid,
        Assassin
    }
}
