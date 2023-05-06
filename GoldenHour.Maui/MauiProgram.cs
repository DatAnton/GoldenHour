using CommunityToolkit.Maui;
using GoldenHour.Maui.DbServices;
using GoldenHour.Maui.Helpers;
using GoldenHour.Maui.Interfaces;
using GoldenHour.Maui.Managers;
using GoldenHour.Maui.Pages;
using GoldenHour.Maui.Services;
using GoldenHour.Maui.ViewModels;
using ZXing.Net.Maui;

namespace GoldenHour.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseBarcodeReader()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .ConfigureMauiHandlers(h =>
                {
                    h.AddHandler(typeof(ZXing.Net.Maui.Controls.CameraBarcodeReaderView), typeof(CameraBarcodeReaderViewHandler));
                    h.AddHandler(typeof(ZXing.Net.Maui.Controls.CameraView), typeof(CameraViewHandler));
                    h.AddHandler(typeof(ZXing.Net.Maui.Controls.BarcodeGeneratorView), typeof(BarcodeGeneratorViewHandler));
                });

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "goldenHour.db3");

            builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<DatabaseService>(s, dbPath));

            #region Helpers

            builder.Services.AddSingleton<UserInfoHelper>();
            builder.Services.AddSingleton<QRCodeHelper>();
            builder.Services.AddSingleton<TabsBuilder>();
            builder.Services.AddSingleton<GeoHelper>();

            #endregion

            #region Services

            builder.Services.AddTransient<IAccountService, AccountService>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IIncidentService, IncidentService>();

            #endregion

            #region Managers

            builder.Services.AddScoped<IncidentManager>();

            #endregion

            #region ViewModels

            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<LoadingPageViewModel>();
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<ChangePasswordViewModel>();
            builder.Services.AddScoped<NewIncidentPageViewModel>();
            builder.Services.AddScoped<HistoryViewModel>();

            #endregion

            #region Pages

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<LoadingPage>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddScoped<NewIncidentPage>();
            builder.Services.AddSingleton<HistoryPage>();

            #endregion

            return builder.Build();
        }
    }
}