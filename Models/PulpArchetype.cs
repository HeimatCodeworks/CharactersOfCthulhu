using System.Collections.Generic;

namespace CharactersOfCthulhu.Models
{
    public class PulpArchetype
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<string> CoreCharacteristicOptions { get; set; } = new();
    }
}