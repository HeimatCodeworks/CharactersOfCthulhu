using CharactersOfCthulhu;
using CharactersOfCthulhu.Services;
using CharactersOfCthulhu.ViewModels;
using CharactersOfCthulhu.Views;
using CommunityToolkit.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<CharacterCreationService>();

        builder.Services.AddTransient<LandingPage>();
        builder.Services.AddTransient<LandingPageViewModel>();

        builder.Services.AddTransient<MethodSelectionPage>();
        builder.Services.AddTransient<MethodSelectionViewModel>();

        builder.Services.AddTransient<StatsPage>();
        builder.Services.AddTransient<StatsViewModel>();

        builder.Services.AddTransient<OccupationPageViewModel>();
        builder.Services.AddTransient<OccupationPage>();

        builder.Services.AddTransient<CustomOccupationPageViewModel>();
        builder.Services.AddTransient<CustomOccupationPage>();

        builder.Services.AddTransient<SkillsPageViewModel>();
        builder.Services.AddTransient<SkillsPage>();

        builder.Services.AddTransient<EraPage>();
        builder.Services.AddTransient<EraPageViewModel>();

        builder.Services.AddTransient<PulpOrClassicPage>();
        builder.Services.AddTransient<PulpOrClassicPageViewModel>();

        return builder.Build();
    }
}