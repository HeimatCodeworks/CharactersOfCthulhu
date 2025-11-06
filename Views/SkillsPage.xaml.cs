using CharactersOfCthulhu.ViewModels;

namespace CharactersOfCthulhu.Views;

public partial class SkillsPage : ContentPage
{
    public SkillsPage(SkillsPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}