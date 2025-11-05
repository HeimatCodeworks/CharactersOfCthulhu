using CharactersOfCthulhu.ViewModels;

namespace CharactersOfCthulhu.Views;

public partial class LandingPage : ContentPage
{
    public LandingPage(LandingPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}