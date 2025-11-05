using System.Collections.Generic;

namespace CharactersOfCthulhu.Models
{

    public class Occupation
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public string SkillPointFormula { get; set; }

        public string CreditRatingRange { get; set; }

        public List<string> Skills { get; set; } = new();
    }
}