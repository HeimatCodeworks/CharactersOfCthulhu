using CharactersOfCthulhu.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;

namespace CharactersOfCthulhu.ViewModels
{
    public partial class ArchetypeViewModel : ObservableObject
    {
        public PulpArchetype Archetype { get; }
        public string Name => Archetype.Name;
        public string Description => Archetype.Description;

        [ObservableProperty]
        private bool _isExpanded;

        [ObservableProperty]
        private bool _showCoreCharacteristicChoice;

        [ObservableProperty]
        private ObservableCollection<string> _coreCharacteristicChoices;

        [ObservableProperty]
        private string _selectedCoreCharacteristic;

        public ArchetypeViewModel(PulpArchetype archetype)
        {
            Archetype = archetype;

            _coreCharacteristicChoices = new ObservableCollection<string>(archetype.CoreCharacteristicOptions);
            _selectedCoreCharacteristic = archetype.CoreCharacteristicOptions.FirstOrDefault();
        }

        public void HandleSelection(bool isSelected)
        {
            IsExpanded = isSelected;
            ShowCoreCharacteristicChoice = isSelected && Archetype.CoreCharacteristicOptions.Count > 1;
        }
    }
}