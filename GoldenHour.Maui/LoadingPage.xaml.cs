using GoldenHour.Maui.ViewModels;

namespace GoldenHour.Maui;

public partial class LoadingPage : ContentPage
{
	public LoadingPage(LoadingPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}