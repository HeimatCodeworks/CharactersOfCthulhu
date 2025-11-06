using CharactersOfCthulhu.ViewModels;

namespace CharactersOfCthulhu.Views;

public partial class CustomOccupationPage : ContentPage
{
    public CustomOccupationPage(CustomOccupationPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is CustomOccupationPageViewModel vm)
        {
            vm.Initialize();
        }
    }
}