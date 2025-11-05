using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using CharactersOfCthulhu.Views;

namespace CharactersOfCthulhu.ViewModels
{
    public partial class LandingPageViewModel : ObservableObject
    {
        public LandingPageViewModel()
        {
        }

        [RelayCommand]
        private async Task GoToCreateNew()
        {
            await Shell.Current.GoToAsync(nameof(MethodSelectionPage));
        }

        [RelayCommand]
        private async Task GoToLoad()
        {
            await Shell.Current.DisplayAlert("Not Implemented", "Loading characters will be implemented in a future step.", "OK");
        }
    }
}