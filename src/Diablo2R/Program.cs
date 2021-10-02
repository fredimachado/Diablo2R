using Diablo2R.Core;
using System;

namespace Diablo2R.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = @"C:\Users\Fredi\Saved Games\Diablo II Resurrected\Fredi.d2s";

            var d2s = new D2s(filePath);
            
            Console.WriteLine($"Character Name: {d2s.Header.CharacterName}");
            Console.WriteLine($"Character Class: {d2s.Header.CharacterClass}");
            Console.WriteLine($"Character Level: {d2s.Header.CharacterLevel}");
            Console.WriteLine($"Last Played: {d2s.Header.LastPlayed}");

            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Strength: {d2s.Attributes.Strength}");
            Console.WriteLine($"Energy: {d2s.Attributes.Energy}");
            Console.WriteLine($"Dexterity: {d2s.Attributes.Dexterity}");
            Console.WriteLine($"Vitality: {d2s.Attributes.Vitality}");
            Console.WriteLine($"UnusedStats: {d2s.Attributes.UnusedStats}");
            Console.WriteLine($"UnusedSkills: {d2s.Attributes.UnusedSkills}");
            Console.WriteLine($"CurrentHP: {d2s.Attributes.CurrentHP}");
            Console.WriteLine($"MaxHP: {d2s.Attributes.MaxHP}");
            Console.WriteLine($"CurrentMana: {d2s.Attributes.CurrentMana}");
            Console.WriteLine($"MaxMana: {d2s.Attributes.MaxMana}");
            Console.WriteLine($"CurrentStamina: {d2s.Attributes.CurrentStamina}");
            Console.WriteLine($"MaxStamina: {d2s.Attributes.MaxStamina}");
            Console.WriteLine($"Level: {d2s.Attributes.Level}");
            Console.WriteLine($"Experience: {d2s.Attributes.Experience}");
            Console.WriteLine($"Gold: {d2s.Attributes.Gold}");
            Console.WriteLine($"StashedGold: {d2s.Attributes.StashedGold}");

        }
    }
}
