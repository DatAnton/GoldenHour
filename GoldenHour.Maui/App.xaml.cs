using GoldenHour.Maui.DbServices;
using GoldenHour.Maui.Models;

namespace GoldenHour.Maui
{
    public partial class App : Application
    {
        public static UserInfo UserInfo;
        public static DatabaseService DbService { get; private set; }
        public App(DatabaseService dbService)
        {
            InitializeComponent();

            MainPage = new AppShell();
            DbService = dbService;
        }
    }
}