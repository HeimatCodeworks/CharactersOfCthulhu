using CharactersOfCthulhu.ViewModels;

namespace CharactersOfCthulhu.Views;

public partial class MethodSelectionPage : ContentPage
{
    public MethodSelectionPage(MethodSelectionViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}