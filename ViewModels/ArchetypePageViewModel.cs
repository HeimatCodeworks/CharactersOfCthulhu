using CharactersOfCthulhu.Models;
using CharactersOfCthulhu.Repositories;
using CharactersOfCthulhu.Services;
using CharactersOfCthulhu.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CharactersOfCthulhu.ViewModels
{
    public partial class ArchetypePageViewModel : ObservableObject
    {
        private readonly CharacterCreationService _characterService;

        [ObservableProperty]
        private ObservableCollection<ArchetypeViewModel> _archetypes;

        [ObservableProperty]
        private ArchetypeViewModel _selectedArchetype;

        [ObservableProperty]
        private bool _showCoreCharacteristicChoice;

        [ObservableProperty]
        private ObservableCollection<string> _coreCharacteristicChoices;

        [ObservableProperty]
        private string _selectedCoreCharacteristic;

        public ArchetypePageViewModel(CharacterCreationService characterService)
        {
            _characterService = characterService;
            LoadArchetypes();
        }

        private void LoadArchetypes()
        {
            var models = ArchetypeRepository.GetArchetypes();
            var vms = models.Select(m => new ArchetypeViewModel(m));
            Archetypes = new ObservableCollection<ArchetypeViewModel>(vms);
        }

        partial void OnSelectedArchetypeChanged(ArchetypeViewModel value)
        {
            foreach (var vm in Archetypes)
            {
                vm.IsExpanded = (vm == value);
            }

            if (value == null)
            {
                ShowCoreCharacteristicChoice = false;
                return;
            }

            var options = value.Archetype.CoreCharacteristicOptions;
            if (options.Count > 1)
            {
                CoreCharacteristicChoices = new ObservableCollection<string>(options);
                SelectedCoreCharacteristic = options.First();
                ShowCoreCharacteristicChoice = true;
            }
            else
            {
                ShowCoreCharacteristicChoice = false;
                SelectedCoreCharacteristic = options.FirstOrDefault();
            }
        }

        [RelayCommand]
        private async Task GoToNextPage()
        {
            if (SelectedArchetype == null)
            {
                await Shell.Current.DisplayAlert("No Archetype", "Please select an archetype to continue.", "OK");
                return;
            }

            _characterService.SelectedArchetype = SelectedArchetype.Archetype;
            _characterService.SelectedCoreCharacteristic = SelectedCoreCharacteristic;

            await Shell.Current.GoToAsync(nameof(MethodSelectionPage));
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}