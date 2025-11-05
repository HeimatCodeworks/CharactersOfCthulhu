using CharactersOfCthulhu.Views;

namespace CharactersOfCthulhu;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(StatsPage), typeof(StatsPage));
    }
}