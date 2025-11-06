using CharactersOfCthulhu.Views;

namespace CharactersOfCthulhu;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(EraPage), typeof(EraPage));
        Routing.RegisterRoute(nameof(MethodSelectionPage), typeof(MethodSelectionPage));
        Routing.RegisterRoute(nameof(StatsPage), typeof(StatsPage));
        Routing.RegisterRoute(nameof(OccupationPage), typeof(OccupationPage));
        Routing.RegisterRoute(nameof(CustomOccupationPage), typeof(CustomOccupationPage));
        Routing.RegisterRoute(nameof(SkillsPage), typeof(SkillsPage));
        Routing.RegisterRoute(nameof(PulpOrClassicPage), typeof(PulpOrClassicPage));
        Routing.RegisterRoute(nameof(MethodSelectionPage), typeof(MethodSelectionPage));
        Routing.RegisterRoute(nameof(ArchetypePage), typeof(ArchetypePage));
    }
}