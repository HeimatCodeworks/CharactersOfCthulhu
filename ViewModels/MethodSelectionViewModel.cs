using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using CharactersOfCthulhu.Views;
using CharactersOfCthulhu.Services;

namespace CharactersOfCthulhu.ViewModels
{

    /// ViewModel for the character creation method selection page.
    public partial class MethodSelectionViewModel : ObservableObject
    {
        private readonly CharacterCreationService _characterService;
        public MethodSelectionViewModel(CharacterCreationService characterService)
        {
            _characterService = characterService;
        }

        [RelayCommand]
        private async Task SelectMethod(string method)
        {
            if (string.IsNullOrEmpty(method))
                return;

            _characterService.StartNewCharacter(method);

            string route = nameof(StatsPage);
            await Shell.Current.GoToAsync($"{route}?method={method}");
        }

        [RelayCommand]
        private async Task GoBack()
        {
            _characterService.ClearCharacter();
            await Shell.Current.GoToAsync("..");
        }
    }
}