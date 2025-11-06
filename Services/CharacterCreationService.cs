using CharactersOfCthulhu.Models;

namespace CharactersOfCthulhu.Services
{
    public class CharacterCreationService
    {
        public BaseInvestigator CurrentInvestigator { get; private set; }

        public string SelectedMethod { get; private set; }

        public Era SelectedEra { get; set; } = Era.Classic1920s;

        public PulpArchetype SelectedArchetype { get; set; }

        public string SelectedCoreCharacteristic { get; set; }

        public void StartCreationProcess(string methodName)
        {
            SelectedMethod = methodName;
            if (methodName.Contains("Pulp"))
            {
                CurrentInvestigator = new PulpHero();
            }
            else
            {
                CurrentInvestigator = new ClassicInvestigator();
            }

            CurrentInvestigator.Era = SelectedEra;
        }

        public bool IsPulp { get; set; }
    }
}
