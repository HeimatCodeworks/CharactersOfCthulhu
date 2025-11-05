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

        return builder.Build();
    }
}