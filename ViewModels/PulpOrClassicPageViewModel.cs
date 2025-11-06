using CharactersOfCthulhu.Services;
using CharactersOfCthulhu.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharactersOfCthulhu.ViewModels
{
    public class GameStyleChoice
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPulp { get; set; }
        public bool IsDefault { get; set; }
    }

    public partial class PulpOrClassicPageViewModel : ObservableObject
    {
        private readonly CharacterCreationService _characterService;

        public List<GameStyleChoice> GameStyleChoices { get; } = new()
        {
            new GameStyleChoice
            {
                Name = "Classic",
                Description = "Standard rules for ordinary investigators.",
                IsPulp = false,
                IsDefault = true
            },
            new GameStyleChoice
            {
                Name = "Pulp",
                Description = "Action-oriented rules for heroic characters.",
                IsPulp = true,
                IsDefault = false
            }
        };

        [ObservableProperty]
        private string _selectedGameStyleName;

        public PulpOrClassicPageViewModel(CharacterCreationService characterService)
        {
            _characterService = characterService;
            SelectedGameStyleName = GameStyleChoices.First(g => g.IsDefault).Name;
        }

        [RelayCommand]
        private async Task GoToNextPage()
        {
            var selectedStyle = GameStyleChoices
                .FirstOrDefault(g => g.Name == SelectedGameStyleName) ?? GameStyleChoices.First();

            _characterService.IsPulp = selectedStyle.IsPulp;

            await Shell.Current.GoToAsync(nameof(MethodSelectionPage));
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}