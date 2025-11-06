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
                vm.HandleSelection(vm == value);
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
            _characterService.SelectedCoreCharacteristic = SelectedArchetype.SelectedCoreCharacteristic;

            await Shell.Current.GoToAsync(nameof(MethodSelectionPage));
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}