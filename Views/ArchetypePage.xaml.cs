using CharactersOfCthulhu.ViewModels;

namespace CharactersOfCthulhu.Views;

public partial class ArchetypePage : ContentPage
{
    public ArchetypePage(ArchetypePageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}