using GoldenHour.Maui.ViewModels;

namespace GoldenHour.Maui;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}