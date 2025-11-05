using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System;
using CharactersOfCthulhu.Services;
using CharactersOfCthulhu.Models;
using CharactersOfCthulhu.Views;

namespace CharactersOfCthulhu.ViewModels
{
    [QueryProperty(nameof(SelectedMethod), "method")]
    public partial class StatsViewModel : ObservableObject
    {
        private readonly CharacterCreationService _characterService;
        private BaseInvestigator _investigator;

        [ObservableProperty]
        private string _selectedMethod;

        public bool IsRollMode => SelectedMethod?.Contains("Roll") ?? false;

        public bool IsPointBuyMode => SelectedMethod?.Contains("PointBuy") ?? false;

        public bool IsFreeformMode => SelectedMethod == "Freeform";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(RemainingPoints))]
        private int _distributablePointPool;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(RemainingPoints))]
        private int _totalPointsAllocated;

        private int _totalMinimumCost;
        public int RemainingPoints => DistributablePointPool - TotalPointsAllocated;
        private int _minStr, _minCon, _minSiz, _minDex, _minApp, _minInt, _minPow, _minEdu;

        [ObservableProperty]
        private int _strength;
        [ObservableProperty]
        private int _constitution;
        [ObservableProperty]
        private int _size;
        [ObservableProperty]
        private int _dexterity;
        [ObservableProperty]
        private int _appearance;
        [ObservableProperty]
        private int _intelligence;
        [ObservableProperty]
        private int _power;
        [ObservableProperty]
        private int _education;

        private readonly Random _random = new();

        public StatsViewModel(CharacterCreationService characterService)
        {
            _characterService = characterService;
            _investigator = _characterService.CurrentInvestigator;
        }

        #region Property Changed Handlers

        partial void OnSelectedMethodChanged(string value)
        {
            _investigator = _characterService.CurrentInvestigator;

            OnPropertyChanged(nameof(IsRollMode));
            OnPropertyChanged(nameof(IsPointBuyMode));
            OnPropertyChanged(nameof(IsFreeformMode));

            if (IsRollMode)
            {
                RollAllStats();
            }
            else
            {
                InitializePointBuy();
            }
        }

        private void UpdateAllocatedPoints()
        {
            if (IsRollMode) return;

            int totalValue = Strength + Constitution + Size + Dexterity +
                             Appearance + Intelligence + Power + Education;
            TotalPointsAllocated = totalValue - _totalMinimumCost;
        }
        partial void OnStrengthChanged(int value) => UpdateAllocatedPoints();
        partial void OnConstitutionChanged(int value) => UpdateAllocatedPoints();
        partial void OnSizeChanged(int value) => UpdateAllocatedPoints();
        partial void OnDexterityChanged(int value) => UpdateAllocatedPoints();
        partial void OnAppearanceChanged(int value) => UpdateAllocatedPoints();
        partial void OnIntelligenceChanged(int value) => UpdateAllocatedPoints();
        partial void OnPowerChanged(int value) => UpdateAllocatedPoints();
        partial void OnEducationChanged(int value) => UpdateAllocatedPoints();

        #endregion

        #region Point-Buy Logic

        private void InitializePointBuy()
        {
            if (SelectedMethod == "ClassicPointBuy")
            {
                _minStr = _minCon = _minDex = _minApp = _minPow = 15;
                _minSiz = _minInt = _minEdu = 40;
                _totalMinimumCost = 195;
                DistributablePointPool = 265;
            }
            else if (SelectedMethod == "PulpPointBuy")
            {
                _minStr = _minCon = _minSiz = _minDex = _minApp = _minInt = _minPow = _minEdu = 15;
                _totalMinimumCost = 120;
                DistributablePointPool = 430;
            }
            else if (SelectedMethod == "Freeform")
            {
                _minStr = _minCon = _minSiz = _minDex = _minApp = _minInt = _minPow = _minEdu = 0;
                _totalMinimumCost = 0;
                DistributablePointPool = 1500;
            }

            ResetStatsToMinimum();
        }

        [RelayCommand]
        private void ModifyStatFixed(string parameter)
        {
            if (string.IsNullOrEmpty(parameter)) return;
            var parts = parameter.Split(',');
            string characteristic = parts[0];
            if (!int.TryParse(parts[1], out int amount)) return;

            if (amount > 0 && RemainingPoints < amount)
            {
                return;
            }

            int maxStat = (SelectedMethod == "Freeform") ? int.MaxValue : 90;

            switch (characteristic)
            {
                case "Strength": Strength = Math.Clamp(Strength + amount, _minStr, maxStat); break;
                case "Constitution": Constitution = Math.Clamp(Constitution + amount, _minCon, maxStat); break;
                case "Size": Size = Math.Clamp(Size + amount, _minSiz, maxStat); break;
                case "Dexterity": Dexterity = Math.Clamp(Dexterity + amount, _minDex, maxStat); break;
                case "Appearance": Appearance = Math.Clamp(Appearance + amount, _minApp, maxStat); break;
                case "Intelligence": Intelligence = Math.Clamp(Intelligence + amount, _minInt, maxStat); break;
                case "Power": Power = Math.Clamp(Power + amount, _minPow, maxStat); break;
                case "Education": Education = Math.Clamp(Education + amount, _minEdu, maxStat); break;
            }
        }

        [RelayCommand]
        private void ResetStatsToMinimum()
        {
            Strength = _minStr;
            Constitution = _minCon;
            Size = _minSiz;
            Dexterity = _minDex;
            Appearance = _minApp;
            Intelligence = _minInt;
            Power = _minPow;
            Education = _minEdu;
        }

        #endregion

        #region Dice Rolling Logic (Restored)

        private int Roll3D6x5() => (_random.Next(1, 7) + _random.Next(1, 7) + _random.Next(1, 7)) * 5;
        private int Roll2D6Plus6x5() => (_random.Next(1, 7) + _random.Next(1, 7) + 6) * 5;
        private int Roll3D6Plus3x5() => (_random.Next(1, 7) + _random.Next(1, 7) + _random.Next(1, 7) + 3) * 5;

        [RelayCommand]
        private void RollAllStats()
        {
            Strength = Roll3D6x5();
            Constitution = Roll3D6x5();
            Dexterity = Roll3D6x5();
            Appearance = Roll3D6x5();
            Power = Roll3D6x5();
            Intelligence = Roll2D6Plus6x5();
            Size = Roll2D6Plus6x5();
            Education = Roll3D6Plus3x5();
        }
        [RelayCommand]
        private void RollStrength() => Strength = Roll3D6x5();
        [RelayCommand]
        private void RollConstitution() => Constitution = Roll3D6x5();
        [RelayCommand]
        private void RollSize() => Size = Roll2D6Plus6x5();
        [RelayCommand]
        private void RollDexterity() => Dexterity = Roll3D6x5();
        [RelayCommand]
        private void RollAppearance() => Appearance = Roll3D6x5();
        [RelayCommand]
        private void RollIntelligence() => Intelligence = Roll2D6Plus6x5();
        [RelayCommand]
        private void RollPower() => Power = Roll3D6x5();
        [RelayCommand]
        private void RollEducation() => Education = Roll3D6Plus3x5();

        #endregion

        #region Navigation Commands

        private void SaveStatsToCharacter()
        {
            if (_investigator == null)
            {
                Shell.Current.DisplayAlert("Error", "Character data was lost. Please go back and restart.", "OK");
                return;
            }

            if (_investigator.Characteristics == null)
            {
                _investigator.Characteristics = new Characteristics();
            }

            _investigator.Characteristics.Strength = Strength;
            _investigator.Characteristics.Constitution = Constitution;
            _investigator.Characteristics.Size = Size;
            _investigator.Characteristics.Dexterity = Dexterity;
            _investigator.Characteristics.Appearance = Appearance;
            _investigator.Characteristics.Intelligence = Intelligence;
            _investigator.Characteristics.Power = Power;
            _investigator.Characteristics.Education = Education;
        }

        [RelayCommand]
        private async Task GoToSkillsPage()
        {
            if (IsPointBuyMode && RemainingPoints != 0)
            {
                await Shell.Current.DisplayAlert("Validation Error", $"You must allocate all {DistributablePointPool} distributable points. You have {RemainingPoints} points remaining.", "OK");
                return;
            }

            SaveStatsToCharacter();

            await Shell.Current.GoToAsync(nameof(OccupationPage));
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        #endregion
    }
}