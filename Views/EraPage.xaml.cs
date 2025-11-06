using CharactersOfCthulhu.ViewModels;

namespace CharactersOfCthulhu.Views;

public partial class EraPage : ContentPage
{
    public EraPage(EraPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}