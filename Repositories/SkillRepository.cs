using CharactersOfCthulhu.Models;

namespace CharactersOfCthulhu.Repositories
{
    public static class SkillRepository
    {
        private static List<Skill> _skills = new List<Skill>
        {
            // --- Academic ---
            new Skill { Name = "Accounting", Category = "Academic", BaseValue = 5, AvailableInEra = Era.All },
            new Skill { Name = "Anthropology", Category = "Academic", BaseValue = 1, AvailableInEra = Era.All },
            new Skill { Name = "Archaeology", Category = "Academic", BaseValue = 1, AvailableInEra = Era.All },
            new Skill { Name = "Astronomy", Category = "Academic", BaseValue = 1, AvailableInEra = Era.All },
            new Skill { Name = "Cthulhu Mythos", Category = "Academic", BaseValue = 0, AvailableInEra = Era.All },
            new Skill { Name = "History", Category = "Academic", BaseValue = 5, AvailableInEra = Era.All },
            new Skill { Name = "Law", Category = "Academic", BaseValue = 5, AvailableInEra = Era.All },
            new Skill { Name = "Library Use", Category = "Academic", BaseValue = 20, AvailableInEra = Era.All },
            new Skill { Name = "Meteorology", Category = "Academic", BaseValue = 1, AvailableInEra = Era.All },
            new Skill { Name = "Natural World", Category = "Academic", BaseValue = 10, AvailableInEra = Era.All },
            new Skill { Name = "Occult", Category = "Academic", BaseValue = 5, AvailableInEra = Era.All },

            // --- Interpersonal ---
            new Skill { Name = "Charm", Category = "Interpersonal", BaseValue = 15, AvailableInEra = Era.All },
            new Skill { Name = "Credit Rating", Category = "Interpersonal", BaseValue = 0, AvailableInEra = Era.All },
            new Skill { Name = "Fast Talk", Category = "Interpersonal", BaseValue = 5, AvailableInEra = Era.All },
            new Skill { Name = "Intimidate", Category = "Interpersonal", BaseValue = 15, AvailableInEra = Era.All },
            new Skill { Name = "Persuade", Category = "Interpersonal", BaseValue = 10, AvailableInEra = Era.All },
            new Skill { Name = "Psychology", Category = "Interpersonal", BaseValue = 10, AvailableInEra = Era.All },

            // --- Practical ---
            new Skill { Name = "Appraise", Category = "Practical", BaseValue = 5, AvailableInEra = Era.All },
            new Skill { Name = "Art/Craft (any)", Category = "Practical", BaseValue = 5, AvailableInEra = Era.All },
            new Skill { Name = "Disguise", Category = "Practical", BaseValue = 5, AvailableInEra = Era.All },
            new Skill { Name = "Drive Auto", Category = "Practical", BaseValue = 20, AvailableInEra = Era.All },
            new Skill { Name = "Electrical Repair", Category = "Practical", BaseValue = 10, AvailableInEra = Era.All },
            new Skill { Name = "First Aid", Category = "Practical", BaseValue = 30, AvailableInEra = Era.All },
            new Skill { Name = "Listen", Category = "Practical", BaseValue = 20, AvailableInEra = Era.All },
            new Skill { Name = "Locksmith", Category = "Practical", BaseValue = 1, AvailableInEra = Era.All },
            new Skill { Name = "Mechanical Repair", Category = "Practical", BaseValue = 10, AvailableInEra = Era.All },
            new Skill { Name = "Navigate", Category = "Practical", BaseValue = 10, AvailableInEra = Era.All },
            new Skill { Name = "Operate Heavy Machinery", Category = "Practical", BaseValue = 1, AvailableInEra = Era.All },
            new Skill { Name = "Sleight of Hand", Category = "Practical", BaseValue = 10, AvailableInEra = Era.All },
            new Skill { Name = "Spot Hidden", Category = "Practical", BaseValue = 25, AvailableInEra = Era.All },
            new Skill { Name = "Stealth", Category = "Practical", BaseValue = 20, AvailableInEra = Era.All },
            new Skill { Name = "Swim", Category = "Practical", BaseValue = 20, AvailableInEra = Era.All },
            new Skill { Name = "Throw", Category = "Practical", BaseValue = 20, AvailableInEra = Era.All },

            // --- Combat ---
            new Skill { Name = "Fighting (Brawl)", Category = "Combat", BaseValue = 25, AvailableInEra = Era.All },
            new Skill { Name = "Fighting (Axe)", Category = "Combat", BaseValue = 15, AvailableInEra = Era.All },
            new Skill { Name = "Fighting (Garrote)", Category = "Combat", BaseValue = 15, AvailableInEra = Era.All },
            new Skill { Name = "Fighting (Sword)", Category = "Combat", BaseValue = 20, AvailableInEra = Era.All },
            new Skill { Name = "Firearms (Handgun)", Category = "Combat", BaseValue = 20, AvailableInEra = Era.All },
            new Skill { Name = "Firearms (Rifle/Shotgun)", Category = "Combat", BaseValue = 25, AvailableInEra = Era.All },

            // --- Dynamic/Special ---
            new Skill {
                Name = "Dodge", Category = "Special", BaseValue = 0,
                BaseValueDependsOn = "DEX",
                BaseValueCalculation = val => val / 2,
                AvailableInEra = Era.All
            },
            new Skill {
                Name = "Language (Own)", Category = "Special", BaseValue = 0,
                BaseValueDependsOn = "EDU",
                BaseValueCalculation = val => val,
                AvailableInEra = Era.All
            },
            new Skill { Name = "Language (Other)", Category = "Special", BaseValue = 1, AvailableInEra = Era.All },

            // --- Modern Era ---
            new Skill { Name = "Computer Use", Category = "Modern", BaseValue = 0, AvailableInEra = Era.Modern },
            new Skill { Name = "Electronics", Category = "Modern", BaseValue = 1, AvailableInEra = Era.Modern },
            
            // --- Science ---
            new Skill { Name = "Science (Biology)", Category = "Science", BaseValue = 1, AvailableInEra = Era.All },
            new Skill { Name = "Science (Botany)", Category = "Science", BaseValue = 1, AvailableInEra = Era.All },
            new Skill { Name = "Science (Chemistry)", Category = "Science", BaseValue = 1, AvailableInEra = Era.All },
            new Skill { Name = "Science (Cryptography)", Category = "Science", BaseValue = 1, AvailableInEra = Era.All },
            new Skill { Name = "Science (Engineering)", Category = "Science", BaseValue = 1, AvailableInEra = Era.All },
            new Skill { Name = "Science (Forensics)", Category = "Science", BaseValue = 1, AvailableInEra = Era.All },
            new Skill { Name = "Science (Geology)", Category = "Science", BaseValue = 1, AvailableInEra = Era.All },
            new Skill { Name = "Science (Mathematics)", Category = "Science", BaseValue = 10, AvailableInEra = Era.All },
            new Skill { Name = "Science (Medicine)", Category = "Science", BaseValue = 1, AvailableInEra = Era.All },
            new Skill { Name = "Science (Pharmacology)", Category = "Science", BaseValue = 1, AvailableInEra = Era.All },
            new Skill { Name = "Science (Physics)", Category = "Science", BaseValue = 1, AvailableInEra = Era.All },
            new Skill { Name = "Science (Zoology)", Category = "Science", BaseValue = 1, AvailableInEra = Era.All },
        };

        public static List<Skill> GetSkills()
        {
            return _skills;
        }
    }
}