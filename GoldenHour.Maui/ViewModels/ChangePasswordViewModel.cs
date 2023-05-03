using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoldenHour.Maui.DTO;
using GoldenHour.Maui.Interfaces;

namespace GoldenHour.Maui.ViewModels
{
    public partial class ChangePasswordViewModel : BaseViewModel
    {

        private readonly IUserService _userService;
        public ChangePasswordViewModel(IUserService userService)
        {
            _userService = userService;
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsOkToSave))]
        string oldPassword;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsOkToSave))]
        string newPassword;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsOkToSave))]
        string confirmPassword;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsErrorMessage))]
        string errorMessage;

        public bool IsErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

        public bool IsOkToSave => !string.IsNullOrWhiteSpace(NewPassword) &&
                !string.IsNullOrWhiteSpace(ConfirmPassword) &&
                !string.IsNullOrWhiteSpace(ConfirmPassword);
        
        public Action<object> OnClose { get; set; }

        [RelayCommand]
        async Task ChangePassword()
        {
            if(!string.IsNullOrWhiteSpace(NewPassword) && 
                !string.IsNullOrWhiteSpace(ConfirmPassword) && 
                !string.IsNullOrWhiteSpace(ConfirmPassword) && 
                NewPassword == ConfirmPassword)
            {
                await _userService.UpdatePassword(new ChangePasswordModel
                {
                    NewPassword = NewPassword,
                    OldPassword = OldPassword,
                    ConfirmPassword = ConfirmPassword
                });
                ClearForm();
                OnClose(true);
                await Shell.Current.DisplayAlert("Info", "The password has been changed", "Ok");
            }
            else
            {
                ErrorMessage = "Confirm password is not correct";
            }
        }

        public void ClearForm()
        {
            OldPassword = string.Empty;
            NewPassword = string.Empty;
            ConfirmPassword = string.Empty;
            ErrorMessage = string.Empty;
        }
    }
}
