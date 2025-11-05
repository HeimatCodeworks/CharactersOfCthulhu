using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System;

namespace CharactersOfCthulhu.ViewModels
{

    [QueryProperty(nameof(SelectedMethod), "method")]
    public partial class StatsViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _selectedMethod;

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

        public StatsViewModel()
        {
        }

        #region Dice Rolling Logic

        private int Roll3D6x5()
        {
            int roll = _random.Next(1, 7) + _random.Next(1, 7) + _random.Next(1, 7);
            return roll * 5;
        }

        private int Roll2D6Plus6x5()
        {
            int roll = _random.Next(1, 7) + _random.Next(1, 7) + 6;
            return roll * 5;
        }

        private int Roll3D6Plus3x5()
        {
            int roll = _random.Next(1, 7) + _random.Next(1, 7) + _random.Next(1, 7) + 3;
            return roll * 5;
        }

        #endregion

        #region Main Commands

        [RelayCommand]
        private void RollStats()
        {
            if (SelectedMethod == "ClassicRoll" || SelectedMethod == "PulpRoll")
            {
                RollAllStats();
            }
            else
            {
                //Set defaults
                Strength = 50;
                Constitution = 50;
                Size = 50;
                Dexterity = 50;
                Appearance = 50;
                Intelligence = 50;
                Power = 50;
                Education = 50;
            }
        }

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
        private async Task GoToSkillsPage()
        {
            // await Shell.Current.GoToAsync("SkillsPage");

            await Shell.Current.DisplayAlert("Navigation", "Proceeding to Skills Page (Not Yet Implemented)", "OK");
        }

        #endregion

        #region Individual Re-roll Commands

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
    }
}