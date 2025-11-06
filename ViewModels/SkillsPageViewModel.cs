using CharactersOfCthulhu.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CharactersOfCthulhu.ViewModels
{
    public partial class SkillsPageViewModel : ObservableObject
    {
        private readonly CharacterCreationService _characterService;

        public SkillsPageViewModel(CharacterCreationService characterService)
        {
            _characterService = characterService;
        }

        [RelayCommand]
        private async Task GoToNextPage()
        {
            await Shell.Current.DisplayAlert("Next Page", "Skills saved (not implemented).", "OK");
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}