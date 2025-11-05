using CharactersOfCthulhu.Models;

namespace CharactersOfCthulhu.Services
{

    public class CharacterCreationService
    {
 
        public BaseInvestigator CurrentInvestigator { get; private set; }

        public string SelectedMethod { get; private set; }

        public void StartNewCharacter(string method)
        {
            SelectedMethod = method;

            if (method.Contains("Pulp"))
            {
                CurrentInvestigator = new PulpHero();
            }
            else
            {
                CurrentInvestigator = new ClassicInvestigator();
            }
        }

        public void ClearCharacter()
        {
            CurrentInvestigator = null;
            SelectedMethod = null;
        }
    }
}