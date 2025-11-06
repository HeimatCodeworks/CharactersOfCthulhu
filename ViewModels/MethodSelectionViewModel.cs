using CharactersOfCthulhu.Services;
using CharactersOfCthulhu.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CharactersOfCthulhu.ViewModels
{
    public partial class MethodSelectionViewModel : ObservableObject
    {
        private readonly CharacterCreationService _characterService;

        [ObservableProperty]
        private bool _isPulp;

        [ObservableProperty]
        private bool _isClassic;

        public MethodSelectionViewModel(CharacterCreationService characterService)
        {
            _characterService = characterService;

            IsPulp = _characterService.IsPulp;
            IsClassic = !_characterService.IsPulp;
        }

        [RelayCommand]
        private async Task SelectMethod(string method)
        {
            if (string.IsNullOrEmpty(method))
                return;

            _characterService.StartCreationProcess(method);

            await Shell.Current.GoToAsync(nameof(StatsPage));
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}