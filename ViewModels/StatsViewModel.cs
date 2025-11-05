using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

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

        public StatsViewModel()
        {
        }

        [RelayCommand]
        private void RollStats()
        {


            if (SelectedMethod == "ClassicRoll")
            {

            }
            else if (SelectedMethod == "PulpRoll")
            {

            }
            else
            {

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

        [RelayCommand]
        private async Task GoToSkillsPage()
        {

            await Shell.Current.DisplayAlert("Navigation", "Proceeding to Skills Page (Not Yet Implemented)", "OK");
        }
    }
}