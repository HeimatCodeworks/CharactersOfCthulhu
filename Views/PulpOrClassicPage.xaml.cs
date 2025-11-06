using CharactersOfCthulhu.ViewModels;

namespace CharactersOfCthulhu.Views;

public partial class PulpOrClassicPage : ContentPage
{
    public PulpOrClassicPage(PulpOrClassicPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
