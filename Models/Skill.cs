namespace CharactersOfCthulhu.Models
{
    //Represents a single investigator skill.
    public class Skill
    {
        public string Name { get; set; }
        public int BaseValue { get; set; }
        public int AllocatedPoints {  get; set; }
        public int TotalValue => BaseValue + AllocatedPoints;
        public bool IsOccupational { get; set; }
    }
}
