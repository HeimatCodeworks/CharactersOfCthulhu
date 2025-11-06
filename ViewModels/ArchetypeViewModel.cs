using CharactersOfCthulhu.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CharactersOfCthulhu.ViewModels
{
    public partial class ArchetypeViewModel : ObservableObject
    {
        public PulpArchetype Archetype { get; }

        public string Name => Archetype.Name;

        public string Description => Archetype.Description;

        [ObservableProperty]
        private bool _isExpanded;

        public ArchetypeViewModel(PulpArchetype archetype)
        {
            Archetype = archetype;
        }
    }
}