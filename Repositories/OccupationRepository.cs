using CharactersOfCthulhu.Models;
using System.Collections.Generic;

namespace CharactersOfCthulhu.Repositories
{
    public static class OccupationRepository
    {
        private static Occupation CustomOccupationOption = new Occupation
        {
            Name = "Create Custom Occupation",
            Description = "Define your own occupation, skills, and credit rating.",
            SkillPointFormula = "Custom",
            CreditRatingRange = "Custom",
            Skills = new List<string>()
        };

        public static List<Occupation> GetClassicOccupations()
        {
            var list = new List<Occupation>
            {
                new Occupation
                {
                    Name = "Antiquarian",
                    Description = "A dealer in or student of antiques or rare objects.",
                    SkillPointFormula = "EDU*2 + APP*2",
                    CreditRatingRange = "30-70",
                    Skills = new List<string> {
                        "Appraise", "Art/Craft (any)", "History", "Library Use",
                        "Language (Other)", "Spot Hidden", "One interpersonal skill",
                        "One other skill"
                    }
                },
                new Occupation
                {
                    Name = "Doctor of Medicine",
                    Description = "A physician or surgeon.",
                    SkillPointFormula = "EDU*4",
                    CreditRatingRange = "30-80",
                    Skills = new List<string> {
                        "First Aid", "Language (Latin)", "Medicine", "Psychology",
                        "Science (Biology)", "Science (Pharmacy)",
                        "One interpersonal skill", "One other skill"
                    }
                },
                new Occupation
                {
                    Name = "Private Investigator",
                    Description = "A 'private eye' hired to investigate.",
                    SkillPointFormula = "EDU*2 + STR*2", // Or DEX*2
                    CreditRatingRange = "9-30",
                    Skills = new List<string> {
                        "Disguise", "Fast Talk", "Intimidate", "Law", "Library Use",
                        "Psychology", "Spot Hidden", "One interpersonal skill"
                    }
                }
            };

            list.Add(CustomOccupationOption);
            return list;
        }

        public static List<Occupation> GetPulpOccupations()
        {
            var list = new List<Occupation>
            {
                new Occupation
                {
                    Name = "Adventurer",
                    Description = "A seeker of fortune in far-flung lands.",
                    SkillPointFormula = "EDU*2 + DEX*2",
                    CreditRatingRange = "10-50",
                    Skills = new List<string> {
                        "Climb", "Fighting (Brawl)", "Firearms", "Jump", "Language (Other)",
                        "Ride", "Survival", "Swim"
                    }
                },
                new Occupation
                {
                    Name = "Dilettante",
                    Description = "A wealthy individual with time on their hands.",
                    SkillPointFormula = "EDU*2 + APP*2",
                    CreditRatingRange = "50-99",
                    Skills = new List<string> {
                        "Appraise", "Art/Craft (any)", "Charm", "Firearms",
                        "Language (Other)", "Ride", "One interpersonal skill",
                        "One other skill"
                    }
                },
                new Occupation
                {
                    Name = "Tough Guy",
                    Description = "A private dick, enforcer, or hard-boiled type.",
                    SkillPointFormula = "EDU*2 + STR*2",
                    CreditRatingRange = "5-30",
                    Skills = new List<string> {
                        "Fighting (Brawl)", "Fast Talk", "Firearms", "Intimidate",
                        "Spot Hidden", "Drive Auto", "Locksmith", "One other skill"
                    }
                }
            };

            list.Add(CustomOccupationOption);
            return list;
        }
    }
}