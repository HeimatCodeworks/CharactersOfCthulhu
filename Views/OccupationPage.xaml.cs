using CharactersOfCthulhu.ViewModels;

namespace CharactersOfCthulhu.Views;

public partial class OccupationPage : ContentPage
{
	public OccupationPage(OccupationPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}