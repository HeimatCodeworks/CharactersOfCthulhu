using CharactersOfCthulhu.Models;
using CharactersOfCthulhu.Repositories;
using CharactersOfCthulhu.Services;
using CharactersOfCthulhu.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CharactersOfCthulhu.ViewModels
{
    public partial class CustomOccupationPageViewModel : ObservableObject
    {
        private readonly CharacterCreationService _characterService;
        private BaseInvestigator _investigator;

        [ObservableProperty]
        private Occupation _customOccupation;

        [ObservableProperty]
        private ObservableCollection<Skill> _allSkills;

        [ObservableProperty]
        private string _skillPointFormulaDisplay;

        [ObservableProperty]
        private string _selectedSkillsCountDisplay;

        public ObservableCollection<object> SelectedSkills { get; set; } = new();

        public ObservableCollection<string> CharacteristicChoices { get; } = new()
        {
            "STR", "CON", "DEX", "APP", "POW", "EDU", "INT", "SIZ"
        };

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SkillPointFormulaDisplay))]
        private string _selectedFormulaCharacteristic = "EDU";

        public CustomOccupationPageViewModel(CharacterCreationService characterService)
        {
            _characterService = characterService;
            _investigator = _characterService.CurrentInvestigator;

            CustomOccupation = new Occupation
            {
                Name = "",
                CreditRatingRange = "",
                Skills = new List<string>()
            };

            SelectedSkills.CollectionChanged += (s, e) => UpdateSkillCount();
            UpdateSkillCount();
            OnSelectedFormulaCharacteristicChanged(SelectedFormulaCharacteristic);
        }

        public void Initialize()
        {
            var era = _characterService.SelectedEra;
            AllSkills = new ObservableCollection<Skill>(
                SkillRepository.GetSkills().Where(s => s.AvailableInEra.HasFlag(era))
            );
        }

        partial void OnSelectedFormulaCharacteristicChanged(string value)
        {
            SkillPointFormulaDisplay = $"Formula: EDU x 2 + {value} x 2";
        }

        private void UpdateSkillCount()
        {
            SelectedSkillsCountDisplay = $"Skills Selected: {SelectedSkills.Count} / 8";
        }

        [RelayCommand]
        private async Task GoToSkillsPage()
        {
            if (string.IsNullOrWhiteSpace(CustomOccupation.Name))
            {
                await Shell.Current.DisplayAlert("Error", "Please enter an Occupation Name.", "OK");
                return;
            }
            if (SelectedSkills.Count != 8)
            {
                await Shell.Current.DisplayAlert("Error", "Please select exactly 8 occupation skills.", "OK");
                return;
            }

            CustomOccupation.SkillPointFormula = $"EDU*2 + {SelectedFormulaCharacteristic}*2";

            CustomOccupation.Skills = SelectedSkills
                .OfType<Skill>()
                .Select(s => s.Name)
                .ToList();

            _investigator.Occupation = CustomOccupation;

            await Shell.Current.GoToAsync($"//{nameof(SkillsPage)}");
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}