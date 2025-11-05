using CharactersOfCthulhu;
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

        builder.Services.AddTransient<LandingPageViewModel>();
        builder.Services.AddTransient<LandingPage>();

        builder.Services.AddTransient<MethodSelectionViewModel>();
        builder.Services.AddTransient<MethodSelectionPage>();

        builder.Services.AddTransient<StatsViewModel>();
        builder.Services.AddTransient<StatsPage>();

        return builder.Build();
    }
}