using Microsoft.Extensions.Logging;
using Tanaffas.Services;
using Tanaffas.ViewModels;
using Tanaffas.Views;

namespace Tanaffas;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("IBMPlexSansArabic-Regular.ttf", "PlexRegular");
                fonts.AddFont("IBMPlexSansArabic-Medium.ttf", "PlexMedium");
                fonts.AddFont("IBMPlexSansArabic-SemiBold.ttf", "PlexSemiBold");
                fonts.AddFont("IBMPlexSansArabic-Bold.ttf", "PlexBold");
            });

        // Navigation service (dependency injection). ViewModels use the interface, not Shell directly. When somebody requests an IAppNavigator, provide an instance of ShellAppNavigator, and reuse that instance.
        builder.Services.AddSingleton<IAppNavigator, ShellAppNavigator>();
        builder.Services.AddSingleton<IDialogService, DialogService>();

        // ViewModels (one per page)
        builder.Services.AddTransient<SignInViewModel>();
        builder.Services.AddTransient<CreateAccountViewModel>();
        builder.Services.AddTransient<TodayViewModel>();
        builder.Services.AddTransient<RiskExplanationViewModel>();
        builder.Services.AddTransient<LogViewModel>();
        builder.Services.AddTransient<TrendsViewModel>();
        builder.Services.AddTransient<ProfileViewModel>();

        // Pages
        builder.Services.AddTransient<SignInPage>();
        builder.Services.AddTransient<CreateAccountPage>();
        builder.Services.AddTransient<TodayPage>();
        builder.Services.AddTransient<RiskExplanationPage>();
        builder.Services.AddTransient<LogPage>();
        builder.Services.AddTransient<TrendsPage>();
        builder.Services.AddTransient<ProfilePage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}

