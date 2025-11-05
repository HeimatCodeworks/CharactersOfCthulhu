using CharactersOfCthulhu.Views;

namespace CharactersOfCthulhu;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(MethodSelectionPage), typeof(MethodSelectionPage));
        Routing.RegisterRoute(nameof(StatsPage), typeof(StatsPage));
    }
}