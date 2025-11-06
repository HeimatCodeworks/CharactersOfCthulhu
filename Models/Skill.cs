using System;

namespace CharactersOfCthulhu.Models
{
    public class Skill
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int BaseValue { get; set; }

        public Era AvailableInEra { get; set; } = Era.All;

        public string BaseValueDependsOn { get; set; } = null;

        public Func<int, int> BaseValueCalculation { get; set; } = val => val;
    }
}