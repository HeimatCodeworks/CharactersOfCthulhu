namespace CharactersOfCthulhu.Models
{

    [Flags]
    public enum Era
    {
        None = 0,
        Classic1920s = 1,
        Modern = 2,
        All = Classic1920s | Modern
    }
}