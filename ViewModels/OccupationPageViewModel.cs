using CharactersOfCthulhu.Models;
using CharactersOfCthulhu.Repositories;
using CharactersOfCthulhu.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CharactersOfCthulhu.ViewModels
{
    public partial class OccupationPageViewModel : ObservableObject
    {
        private readonly CharacterCreationService _characterService;
        private BaseInvestigator _investigator;

        [ObservableProperty]
        private ObservableCollection<Occupation> _occupations;

        [ObservableProperty]
        private Occupation _selectedOccupation;

        public OccupationPageViewModel(CharacterCreationService characterService)
        {
            _characterService = characterService;
            _investigator = _characterService.CurrentInvestigator;

            LoadOccupations();
        }

        private void LoadOccupations()
        {
            if (_characterService.SelectedMethod.Contains("Pulp"))
            {
                Occupations = new ObservableCollection<Occupation>(
                    OccupationRepository.GetPulpOccupations());
            }
            else
            {
                Occupations = new ObservableCollection<Occupation>(
                    OccupationRepository.GetClassicOccupations());
            }
        }

        [RelayCommand]
        private async Task GoToSkillsPage()
        {
            if (SelectedOccupation == null)
            {
                await Shell.Current.DisplayAlert("No Occupation", "Please select an occupation to continue.", "OK");
                return;
            }

            _investigator.Occupation = SelectedOccupation.Name;


            await Shell.Current.DisplayAlert("Navigation", "Proceeding to Skills Page (Not Yet Implemented)", "OK");
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}