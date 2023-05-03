using CommunityToolkit.Maui.Views;
using GoldenHour.Maui.ViewModels;

namespace GoldenHour.Maui.Pages;

public partial class ChangePasswordPopup : Popup
{
    private readonly ChangePasswordViewModel _viewModel;

    public ChangePasswordPopup(ChangePasswordViewModel viewModel)
	{
		InitializeComponent();
		viewModel.OnClose = Close;
		BindingContext = viewModel;
        _viewModel = viewModel;
    }

    private void CloseBtn_Clicked(object sender, EventArgs e)
    {
        _viewModel.ClearForm();
		Close(false);
    }
}