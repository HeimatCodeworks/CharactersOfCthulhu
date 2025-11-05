using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharactersOfCthulhu.Models
{
    //represents pulp investigator
    internal class PulpHero : BaseInvestigator
    {
        public string Archetype { get; set; }
        public List<string> Talents { get; set; } = new();
    }
}
