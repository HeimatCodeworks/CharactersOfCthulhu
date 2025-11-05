using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace CharactersOfCthulhu.ViewModels
{

    /// ViewModel for the character creation method selection page.
    public partial class MethodSelectionViewModel : ObservableObject
    {
        public MethodSelectionViewModel()
        {
            // Constructor
        }

        [RelayCommand]
        private async Task SelectMethod(string method)
        {
            if (string.IsNullOrEmpty(method))
                return;

            await Shell.Current.GoToAsync($"StatsPage?method={method}");
        }
    }
}