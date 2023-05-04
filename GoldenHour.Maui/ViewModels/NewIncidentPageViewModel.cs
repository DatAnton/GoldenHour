﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoldenHour.Maui.Helpers;
using GoldenHour.Maui.Managers;
using GoldenHour.Maui.Models;
using System.Collections.ObjectModel;

namespace GoldenHour.Maui.ViewModels
{
    public partial class NewIncidentPageViewModel : BaseViewModel
    {
        private readonly GeoHelper _geoHelper;
        private readonly IncidentManager _incidentManager;

        public NewIncidentPageViewModel(GeoHelper geoHelper, 
            IncidentManager incidentManager)
        {
            _geoHelper = geoHelper;
            _incidentManager = incidentManager;
        }

        [ObservableProperty]
        string nickName;

        [ObservableProperty]
        string coordinates;

        public ObservableCollection<Photo> Photos { get; private set; } = new ObservableCollection<Photo>();

        [ObservableProperty]
        bool isAnyPhotos;

        [ObservableProperty]
        DateTime currentDate;

        [ObservableProperty]
        TimeSpan currentTime;

        [ObservableProperty]
        bool isDateSetted;

        [ObservableProperty]
        string comment;

        string serviceManId { get; set; }
        GeolocationData geolocationData { get; set; }

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

        [RelayCommand]
        async Task Clear()
        {
            if(await Shell.Current.DisplayAlert("Confirmation", "Do you realy want to clear all?", "Yes", "No"))
            {
                ClearAllFields();
            }
        }

        [RelayCommand]
        async Task Send()
        {
            await _incidentManager.SaveIncident(serviceManId, Photos.Select(p => p.ImageUrl).ToList(),
                geolocationData, CurrentDate, CurrentTime, Comment);
            ClearAllFields();
        }

        private void ClearAllFields()
        {
            NickName = string.Empty;
            Coordinates = string.Empty;
            Photos.Clear();
            IsAnyPhotos = false;
            CurrentDate = DateTime.Today;
            CurrentTime = TimeSpan.Zero;
            IsDateSetted = false;
            Comment = string.Empty;
            serviceManId = string.Empty;
            geolocationData = null;
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

        public async Task SetCurrentLocation()
        {
            geolocationData = await _geoHelper.GetCurrentLocation();
            Coordinates = $"{Math.Round(geolocationData.Latitude, Constants.COORDINATES_ROUND_NUMBERS)}, " +
                $"{Math.Round(geolocationData.Longitude, Constants.COORDINATES_ROUND_NUMBERS)}";
        }

        public void SetCurrentDateTime()
        {
            CurrentDate = DateTime.Today;
            CurrentTime = DateTime.Now.TimeOfDay;
            IsDateSetted = true;
        }

        public void SetQrCodeResult(ScannerResult scannerResult)
        { 
            serviceManId = scannerResult.UserId;
            NickName = scannerResult.NickName; 
        }
    }
}
