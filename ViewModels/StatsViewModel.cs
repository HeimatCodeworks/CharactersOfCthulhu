using CharactersOfCthulhu.Models;
using CharactersOfCthulhu.Services;
using CharactersOfCthulhu.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CharactersOfCthulhu.ViewModels
{
    public partial class StatsViewModel : ObservableObject
    {
        #region Fields
        private readonly CharacterCreationService _characterService;
        private BaseInvestigator _investigator;
        private string _selectedMethod;
        private bool _isPulp;
        private string _coreStat;
        private Random _random = new Random();

        // Point Buy rule constants
        private const int PULP_MIN = 40;
        private const int PULP_MAX = 90;
        private const int CLASSIC_MIN_LOW = 15;
        private const int CLASSIC_MIN_HIGH = 40;
        private const int CLASSIC_MAX = 90;
        #endregion

        #region UI State Properties
        [ObservableProperty]
        private bool _isRollMethod;

        [ObservableProperty]
        private bool _isPointBuyMethod;

        [ObservableProperty]
        private bool _isFreeformMethod;

        [ObservableProperty]
        private int _distributablePoints;

        [ObservableProperty]
        private string _pointBuyTitle = "Point Buy";

        [ObservableProperty]
        private string _pointBuyError;

        public bool IsEditableMethod => IsPointBuyMethod || IsFreeformMethod;

        partial void OnIsPointBuyMethodChanged(bool value)
        {
            OnPropertyChanged(nameof(IsEditableMethod));
        }

        partial void OnIsFreeformMethodChanged(bool value)
        {
            OnPropertyChanged(nameof(IsEditableMethod));
        }
        #endregion

        #region Characteristic Properties
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TotalPoints))]
        private int _str;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TotalPoints))]
        private int _con;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TotalPoints))]
        private int _siz;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TotalPoints))]
        private int _dex;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TotalPoints))]
        private int _app;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TotalPoints))]
        private int _int;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TotalPoints))]
        private int _pow;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TotalPoints))]
        private int _edu;

        public int TotalPoints => Str + Con + Siz + Dex + App + Int + Pow + Edu;
        #endregion

        #region Derived Stat Properties
        [ObservableProperty]
        private int _hp;

        [ObservableProperty]
        private int _mp;

        [ObservableProperty]
        private int _sanity;

        [ObservableProperty]
        private int _luck;
        #endregion

        public StatsViewModel(CharacterCreationService characterService)
        {
            _characterService = characterService;
        }

        public void Initialize()
        {
            _investigator = _characterService.CurrentInvestigator;
            _selectedMethod = _characterService.SelectedMethod;
            _isPulp = _characterService.IsPulp;
            _coreStat = _characterService.SelectedCoreCharacteristic;
            PointBuyError = string.Empty;

            IsRollMethod = _selectedMethod.Contains("Roll");
            IsPointBuyMethod = _selectedMethod.Contains("PointBuy");
            IsFreeformMethod = _selectedMethod.Contains("Freeform");

            if (IsRollMethod)
            {
                RollStats();
            }
            else if (IsPointBuyMethod)
            {
                InitializePointBuy();
            }
            else if (IsFreeformMethod)
            {
                InitializeFreeform();
            }
        }

        #region Dice Rolling Logic
        private int Roll1D6() => _random.Next(1, 7);
        private int Roll2D6() => _random.Next(1, 7) + _random.Next(1, 7);
        private int Roll3D6() => _random.Next(1, 7) + _random.Next(1, 7) + _random.Next(1, 7);

        private int RollClassicStat() => Roll3D6() * 5;

        private int RollClassicHighStat() => (Roll2D6() + 6) * 5;

        private int RollPulpStat(string statName)
        {
            if (statName == _coreStat)
            {
                return (Roll1D6() + 13) * 5;
            }
            return (Roll2D6() + 6) * 5;
        }

        [RelayCommand]
        private void RollStats()
        {
            if (_selectedMethod == "ClassicRoll")
            {
                Str = RollClassicStat();
                Con = RollClassicStat();
                Siz = RollClassicHighStat();
                Dex = RollClassicStat();
                App = RollClassicStat();
                Int = RollClassicHighStat();
                Pow = RollClassicStat();
                Edu = RollClassicHighStat();
            }
            else if (_selectedMethod == "PulpRoll")
            {
                Str = RollPulpStat("STR");
                Con = RollPulpStat("CON");
                Siz = RollPulpStat("SIZ");
                Dex = RollPulpStat("DEX");
                App = RollPulpStat("APP");
                Int = RollPulpStat("INT");
                Pow = RollPulpStat("POW");
                Edu = RollPulpStat("EDU");
            }

            CalculateDerivedStats();
        }

        [RelayCommand]
        private void RerollStat(string statName)
        {
            if (!IsRollMethod) return;

            if (_isPulp)
            {
                switch (statName)
                {
                    case "STR": Str = RollPulpStat("STR"); break;
                    case "CON": Con = RollPulpStat("CON"); break;
                    case "SIZ": Siz = RollPulpStat("SIZ"); break;
                    case "DEX": Dex = RollPulpStat("DEX"); break;
                    case "APP": App = RollPulpStat("APP"); break;
                    case "INT": Int = RollPulpStat("INT"); break;
                    case "POW": Pow = RollPulpStat("POW"); break;
                    case "EDU": Edu = RollPulpStat("EDU"); break;
                }
            }
            else
            {
                switch (statName)
                {
                    case "STR": Str = RollClassicStat(); break;
                    case "CON": Con = RollClassicStat(); break;
                    case "SIZ": Siz = RollClassicHighStat(); break;
                    case "DEX": Dex = RollClassicStat(); break;
                    case "APP": App = RollClassicStat(); break;
                    case "INT": Int = RollClassicHighStat(); break;
                    case "POW": Pow = RollClassicStat(); break;
                    case "EDU": Edu = RollClassicHighStat(); break;
                }
            }
        }

        private void CalculateDerivedStats()
        {
            Mp = Pow / 5;
            Sanity = Pow;

            if (_isPulp)
            {
                Hp = (Con + Siz) / 5;
                Luck = (Roll2D6() + 6) * 5;
            }
            else
            {
                Hp = (Con + Siz) / 10;
                Luck = Roll3D6() * 5;
            }
        }
        #endregion

        #region Point Buy Logic
        private void InitializePointBuy()
        {
            PointBuyTitle = "Point Buy";
            if (_isPulp)
            {
                Str = Con = Siz = Dex = App = Int = Pow = Edu = PULP_MIN;
                DistributablePoints = 280; // 600 - (8 * 40)
            }
            else
            {
                Str = CLASSIC_MIN_LOW; Con = CLASSIC_MIN_LOW; Dex = CLASSIC_MIN_LOW; App = CLASSIC_MIN_LOW; Pow = CLASSIC_MIN_LOW;
                Siz = CLASSIC_MIN_HIGH; Int = CLASSIC_MIN_HIGH; Edu = CLASSIC_MIN_HIGH;
                DistributablePoints = 280; // 460 - (5*15 + 3*40)
            }
            CalculateDerivedStats();
        }

        private void InitializeFreeform()
        {
            PointBuyTitle = "Freeform";
            Str = Con = Siz = Dex = App = Int = Pow = Edu = 0;
            DistributablePoints = 500;
            CalculateDerivedStats();
        }

        [RelayCommand]
        private void ModifyStat(string parameter)
        {
            PointBuyError = string.Empty;
            var parts = parameter.Split(',');
            if (parts.Length != 2) return;

            var statName = parts[0];
            if (!int.TryParse(parts[1], out int amount)) return;

            if (IsPointBuyMethod && amount > 0 && DistributablePoints < amount)
            {
                PointBuyError = "Not enough points remaining.";
                return;
            }

            if (amount > 0 && DistributablePoints < amount)
            {
                PointBuyError = "Not enough points remaining.";
                return;
            }

            int currentValue = statName switch
            {
                "STR" => Str,
                "CON" => Con,
                "SIZ" => Siz,
                "DEX" => Dex,
                "APP" => App,
                "INT" => Int,
                "POW" => Pow,
                "EDU" => Edu,
                _ => 0
            };
            int newValue = currentValue + amount;

            if (IsFreeformMethod)
            {
                if (newValue < 0) { PointBuyError = "Cannot go below 0."; return; }
            }
            else if (IsPointBuyMethod)
            {
                if (newValue > CLASSIC_MAX) { PointBuyError = $"Cannot exceed {CLASSIC_MAX}."; return; }

                if (_isPulp)
                {
                    if (newValue < PULP_MIN) { PointBuyError = $"Cannot go below {PULP_MIN}."; return; }
                }
                else // Classic Point Buy
                {
                    int min = (statName == "SIZ" || statName == "INT" || statName == "EDU") ? CLASSIC_MIN_HIGH : CLASSIC_MIN_LOW;
                    if (newValue < min) { PointBuyError = $"Cannot go below {min}."; return; }
                }
            }

            switch (statName)
            {
                case "STR": Str = newValue; break;
                case "CON": Con = newValue; break;
                case "SIZ": Siz = newValue; break;
                case "DEX": Dex = newValue; break;
                case "APP": App = newValue; break;
                case "INT": Int = newValue; break;
                case "POW": Pow = newValue; break;
                case "EDU": Edu = newValue; break;
            }

            // Update distributable points
            if (IsPointBuyMethod)
            {
                DistributablePoints -= amount;
            }
        }

        // recalculate derived stats on every change.
        partial void OnStrChanged(int value) => CalculateDerivedStats();
        partial void OnConChanged(int value) => CalculateDerivedStats();
        partial void OnSizChanged(int value) => CalculateDerivedStats();
        partial void OnDexChanged(int value) => CalculateDerivedStats();
        partial void OnAppChanged(int value) => CalculateDerivedStats();
        partial void OnIntChanged(int value) => CalculateDerivedStats();
        partial void OnPowChanged(int value) => CalculateDerivedStats();
        partial void OnEduChanged(int value) => CalculateDerivedStats();
        #endregion

        #region Navigation
        [RelayCommand]
        private async Task GoToNextPage()
        {
            if (IsPointBuyMethod&& DistributablePoints != 0)
            {
                PointBuyError = $"You must allocate all {DistributablePoints} remaining points.";
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

        private void SaveStatsToCharacter()
        {
            _investigator.Characteristics = new Characteristics
            {
                STR = this.Str,
                CON = this.Con,
                SIZ = this.Siz,
                DEX = this.Dex,
                APP = this.App,
                INT = this.Int,
                POW = this.Pow,
                EDU = this.Edu
            };

            _investigator.MaxHitPoints = this.Hp;
            _investigator.CurrentHitPoints = this.Hp;
            _investigator.MaxMagicPoints = this.Mp;
            _investigator.CurrentMagicPoints = this.Mp;
            _investigator.MaxSanity = this.Sanity;
            _investigator.CurrentSanity = this.Sanity;
            _investigator.Luck = this.Luck;
        }
        #endregion
    }
}