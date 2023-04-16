using CommunityToolkit.Mvvm.ComponentModel;

namespace GoldenHour.Maui.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        bool isLoading;
    }
}
