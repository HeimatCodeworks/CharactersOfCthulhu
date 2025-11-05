using CharactersOfCthulhu.Models;
using System.Collections.Generic;

namespace CharactersOfCthulhu.Repositories
{
    //static repository for the master list of skills
    internal class SkillRepository
    {
        public static List<Skill> GetBaseSkills()
        {
            return new List<Skill>
            {
                new Skill { Name = "Accounting", BaseValue = 5 },
                new Skill { Name = "Anthropology", BaseValue = 1 },
                new Skill { Name = "Appraise", BaseValue = 5 },
                new Skill { Name = "Archaeology", BaseValue = 1 },
                new Skill { Name = "Art/Craft", BaseValue = 5 }, // Specify
                new Skill { Name = "Charm", BaseValue = 15 },
                new Skill { Name = "Climb", BaseValue = 20 },
                new Skill { Name = "Credit Rating", BaseValue = 0 },
                new Skill { Name = "Cthulhu Mythos", BaseValue = 0 },
                new Skill { Name = "Disguise", BaseValue = 5 },
                new Skill { Name = "Dodge", BaseValue = 0 }, // Calculated: DEX / 2
                new Skill { Name = "Drive Auto", BaseValue = 20 },
                new Skill { Name = "Elec. Repair", BaseValue = 10 },
                new Skill { Name = "Fast Talk", BaseValue = 5 },
                new Skill { Name = "Fighting (Brawl)", BaseValue = 25 },
                new Skill { Name = "Fighting", BaseValue = 0 }, // Specify
                new Skill { Name = "Firearms (Handgun)", BaseValue = 20 },
                new Skill { Name = "Firearms (Rifle/Shotgun)", BaseValue = 25 },
                new Skill { Name = "First Aid", BaseValue = 30 },
                new Skill { Name = "History", BaseValue = 5 },
                new Skill { Name = "Intimidate", BaseValue = 15 },
                new Skill { Name = "Jump", BaseValue = 20 },
                new Skill { Name = "Language (Other)", BaseValue = 1 }, // Specify
                new Skill { Name = "Language (Own)", BaseValue = 0 }, // Calculated: EDU
                new Skill { Name = "Law", BaseValue = 5 },
                new Skill { Name = "Library Use", BaseValue = 20 },
                new Skill { Name = "Listen", BaseValue = 20 },
                new Skill { Name = "Locksmith", BaseValue = 1 },
                new Skill { Name = "Mech. Repair", BaseValue = 10 },
                new Skill { Name = "Medicine", BaseValue = 1 },
                new Skill { Name = "Natural World", BaseValue = 10 },
                new Skill { Name = "Navigate", BaseValue = 10 },
                new Skill { Name = "Occult", BaseValue = 5 },
                new Skill { Name = "Op. Hvy. Machine", BaseValue = 1 },
                new Skill { Name = "Persuasion", BaseValue = 10 },
                new Skill { Name = "Pilot", BaseValue = 1 }, // Specify
                new Skill { Name = "Psychology", BaseValue = 10 },
                new Skill { Name = "Psychoanalysis", BaseValue = 1 },
                new Skill { Name = "Ride", BaseValue = 5 },
                new Skill { Name = "Science", BaseValue = 1 }, // Specify
                new Skill { Name = "Sleight of Hand", BaseValue = 10 },
                new Skill { Name = "Spot Hidden", BaseValue = 25 },
                new Skill { Name = "Stealth", BaseValue = 20 },
                new Skill { Name = "Survival", BaseValue = 10 },
                new Skill { Name = "Swim", BaseValue = 20 },
                new Skill { Name = "Throw", BaseValue = 20 },
                new Skill { Name = "Track", BaseValue = 10 }
            };
        }
    }
}
