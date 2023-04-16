using GoldenHour.Maui.Models;

namespace GoldenHour.Maui
{
    public partial class App : Application
    {
        public static UserInfo UserInfo;
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}