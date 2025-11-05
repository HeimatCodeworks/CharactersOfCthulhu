namespace CharactersOfCthulhu.Models
{
    //Represents the eight core characteristics of an investigator
    public class Characteristics
    {
        public int Strength { get; set; }
        public int Constitution { get; set; }
        public int Size { get; set; }
        public int Dexterity { get; set; }
        public int Appearance { get; set; }
        public int Intelligence { get; set; }
        public int Power { get; set; }
        public int Education { get; set; }
        public int Move { get; set; } //calculated value
    }
}
