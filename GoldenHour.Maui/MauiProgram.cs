using GoldenHour.Maui.Helpers;
using GoldenHour.Maui.Interfaces;
using GoldenHour.Maui.Services;
using GoldenHour.Maui.ViewModels;

namespace GoldenHour.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            #region Helpers

            builder.Services.AddSingleton<TokenHandlerHelper>();

            #endregion

            #region Services

            builder.Services.AddTransient<IAccountService, AccountService>();

            #endregion

            #region ViewModels

            builder.Services.AddSingleton<LoadingPageViewModel>();
            builder.Services.AddSingleton<LoginPageViewModel>();

            #endregion

            #region Pages

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<LoadingPage>();
            builder.Services.AddSingleton<LoginPage>();

            #endregion

            return builder.Build();
        }
    }
}