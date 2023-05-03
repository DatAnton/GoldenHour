using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoldenHour.Maui.Models;
using System.Collections.ObjectModel;

namespace GoldenHour.Maui.ViewModels
{
    public partial class NewIncidentPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        string nickName;

        public ObservableCollection<Photo> Photos { get; private set; } = new ObservableCollection<Photo>();
        [ObservableProperty]
        bool isAnyPhotos;

        string UserId { get; set; }

        [RelayCommand]
        public async void TakePhoto()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                    using Stream sourceStream = await photo.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(localFilePath);

                    await sourceStream.CopyToAsync(localFileStream);

                    Photos.Add(new Photo
                    {
                        ImageUrl = localFilePath
                    });
                    IsAnyPhotos = true;
                }
            }
        }

        public async Task RemovePhoto(Photo photo)
        {
            if (await Shell.Current.DisplayAlert("Confirmation", "Do you realy want to this photo?", "Yes", "No"))
            {
                Photos.Remove(photo);
                if(!Photos.Any())
                    IsAnyPhotos = false;
            }
        }

        public void SetQrCodeResult(ScannerResult scannerResult)
        { 
            UserId = scannerResult.UserId;
            NickName = scannerResult.NickName; 
        }
    }
}
