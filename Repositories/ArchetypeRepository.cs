using CharactersOfCthulhu.Models;
using System.Collections.Generic;

namespace CharactersOfCthulhu.Repositories
{
    public static class ArchetypeRepository
    {
        public static List<PulpArchetype> GetArchetypes()
        {
            return new List<PulpArchetype>
            {
                new PulpArchetype
                {
                    Name = "Adventurer",
                    Description = "Seeking excitement and danger in far-flung places.",
                    CoreCharacteristicOptions = new List<string> { "DEX" }
                },
                new PulpArchetype
                {
                    Name = "Bon Vivant",
                    Description = "A person of leisure, devoted to pleasure and luxury.",
                    CoreCharacteristicOptions = new List<string> { "APP" }
                },
                new PulpArchetype
                {
                    Name = "Dreamer",
                    Description = "Lives a double life, one in the waking world and one in the Dreamlands.",
                    CoreCharacteristicOptions = new List<string> { "POW" }
                },
                new PulpArchetype
                {
                    Name = "Egghead",
                    Description = "An intellectual, scientist, or person of great learning.",
                    CoreCharacteristicOptions = new List<string> { "INT", "EDU" }
                },
                new PulpArchetype
                {
                    Name = "Femme Fatale / Homme Fatale",
                    Description = "A seductive and alluring person who charms others.",
                    CoreCharacteristicOptions = new List<string> { "APP" }
                },
                new PulpArchetype
                {
                    Name = "Hard Boiled",
                    Description = "Tough and cynical, a private eye or grizzled cop.",
                    CoreCharacteristicOptions = new List<string> { "STR", "CON" }
                },
                new PulpArchetype
                {
                    Name = "Investigator",
                    Description = "A seeker of truths, a detective or scholar of the unknown.",
                    CoreCharacteristicOptions = new List<string> { "INT", "EDU" }
                },
                new PulpArchetype
                {
                    Name = "Muckraker",
                    Description = "A journalist or photographer exposing corruption.",
                    CoreCharacteristicOptions = new List<string> { "INT", "EDU" }
                },
            };
        }
    }
}