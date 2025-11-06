using CharactersOfCthulhu.Models;
using CharactersOfCthulhu.Services;
using CharactersOfCthulhu.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharactersOfCthulhu.ViewModels
{
    public class EraChoice
    {
        public string Name { get; set; }
        public Era Value { get; set; }
        public bool IsDefault { get; set; }
    }

    public partial class EraPageViewModel : ObservableObject
    {
        private readonly CharacterCreationService _characterService;

        public List<EraChoice> EraChoices { get; } = new()
        {
            new EraChoice { Name = "Classic (1920s)", Value = Era.Classic1920s, IsDefault = true },
            new EraChoice { Name = "Modern", Value = Era.Modern, IsDefault = false }
        };

        [ObservableProperty]
        private string _selectedEraName;

        public EraPageViewModel(CharacterCreationService characterService)
        {
            _characterService = characterService;
            SelectedEraName = EraChoices.First(e => e.IsDefault).Name;
        }

        [RelayCommand]
        private async Task GoToNextPage()
        {
            var selectedEra = EraChoices
                .FirstOrDefault(e => e.Name == SelectedEraName)
                ?.Value ?? Era.Classic1920s;

            _characterService.SelectedEra = selectedEra;

            await Shell.Current.GoToAsync(nameof(PulpOrClassicPage));
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}