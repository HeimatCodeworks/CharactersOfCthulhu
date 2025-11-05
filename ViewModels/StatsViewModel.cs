using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System;
using System.ComponentModel;

namespace CharactersOfCthulhu.ViewModels
{
    [QueryProperty(nameof(SelectedMethod), "method")]
    public partial class StatsViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _selectedMethod;


        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(RemainingPoints))]
        private int _distributablePointPool;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(RemainingPoints))]
        private int _totalPointsAllocated;

        private int _totalMinimumCost;

        public int RemainingPoints => DistributablePointPool - TotalPointsAllocated;

        public bool IsPointBuyMode => SelectedMethod?.Contains("PointBuy") ?? false;

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


        public StatsViewModel()
        {
        }

        #region Property Changed Handlers

        partial void OnSelectedMethodChanged(string value)
        {
            OnPropertyChanged(nameof(IsPointBuyMode));
            InitializePointBuy();
        }

        private void InitializePointBuy()
        {
            if (SelectedMethod == "ClassicPointBuy")
            {
                _minStr = _minCon = _minDex = _minApp = _minPow = 15;
                _minSiz = _minInt = _minEdu = 40;
                _totalMinimumCost = 195; // (5 * 15) + (3 * 40)
                DistributablePointPool = 265; // 460 - 195
            }
            else if (SelectedMethod == "PulpPointBuy")
            {
                _minStr = _minCon = _minSiz = _minDex = _minApp = _minInt = _minPow = _minEdu = 15;
                _totalMinimumCost = 120; // (8 * 15)
                DistributablePointPool = 430; // 550 - 120
            }
            else if (SelectedMethod == "Freeform")
            {
                _minStr = _minCon = _minSiz = _minDex = _minApp = _minInt = _minPow = _minEdu = 0;
                _totalMinimumCost = 0;
                DistributablePointPool = 1500;
            }

            ResetStats();
        }

        private void UpdateAllocatedPoints()
        {
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

        #region Commands

        [RelayCommand]
        private void ModifyStatFixed(string parameter)
        {
            if (string.IsNullOrEmpty(parameter)) return;

            var parts = parameter.Split(',');
            if (parts.Length != 2) return;

            string characteristic = parts[0];
            if (!int.TryParse(parts[1], out int amount)) return;

            if (amount > 0 && RemainingPoints < amount)
            {
                return;
            }
            int maxStat = (SelectedMethod == "Freeform") ? int.MaxValue : 90;

            switch (characteristic)
            {
                case "Strength":
                    Strength = Math.Clamp(Strength + amount, _minStr, maxStat);
                    break;
                case "Constitution":
                    Constitution = Math.Clamp(Constitution + amount, _minCon, maxStat);
                    break;
                case "Size":
                    Size = Math.Clamp(Size + amount, _minSiz, maxStat);
                    break;
                case "Dexterity":
                    Dexterity = Math.Clamp(Dexterity + amount, _minDex, maxStat);
                    break;
                case "Appearance":
                    Appearance = Math.Clamp(Appearance + amount, _minApp, maxStat);
                    break;
                case "Intelligence":
                    Intelligence = Math.Clamp(Intelligence + amount, _minInt, maxStat);
                    break;
                case "Power":
                    Power = Math.Clamp(Power + amount, _minPow, maxStat);
                    break;
                case "Education":
                    Education = Math.Clamp(Education + amount, _minEdu, maxStat);
                    break;
            }
        }

        [RelayCommand]
        private void ResetStats()
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

        [RelayCommand]
        private async Task GoToSkillsPage()
        {
            if (RemainingPoints != 0)
            {
                await Shell.Current.DisplayAlert("Validation Error", $"You must allocate all {DistributablePointPool} distributable points. You have {RemainingPoints} points remaining.", "OK");
                return;
            }

            await Shell.Current.DisplayAlert("Navigation", "Proceeding to Skills Page (Not Yet Implemented)", "OK");
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        #endregion
    }
}