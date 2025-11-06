using CharactersOfCthulhu.Models;
using System.Collections.Generic;

namespace CharactersOfCthulhu.Models
{
    //abstract base class containing common investigator properties
    public abstract class BaseInvestigator
    {
        //uknique character identifier
        public Guid Id {get; set;} = Guid.NewGuid();
        public string Name {get; set;}
        public Occupation Occupation { get; set; }
        public Characteristics Characteristics {get; set;}
        public Dictionary<string, int> Skills { get; set; } = new Dictionary<string, int>();
        public Era Era { get; set; }

        //derived stats
        public int CurrentHitPoints {get; set;}
        public int MaxHitPoints {get; set;}
        
        public int CurrentSanity {get; set;}
        public int MaxSanity {get; set;}

        public int CurrentMagicPoints {get; set;}
        public int MaxMagicPoints {get; set;}
        
        public int Luck {get; set;}
    }
}
