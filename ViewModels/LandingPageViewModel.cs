using CharactersOfCthulhu.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CharactersOfCthulhu.ViewModels
{
    public partial class LandingPageViewModel : ObservableObject
    {
        public LandingPageViewModel()
        {

        }

        [RelayCommand]
        private async Task GoToCreatePage()
        {
            await Shell.Current.GoToAsync(nameof(EraPage));
        }

        [RelayCommand]
        private async Task GoToLoadPage()
        {
            await Shell.Current.DisplayAlert("Load", "Load investigator not yet implemented.", "OK");
        }
    }
}